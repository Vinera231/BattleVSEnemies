using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class MissingScriptsFinder : EditorWindow
{
    private Vector2 scrollPosition;
    private List<MissingScriptEntry> missingScriptsEntries = new List<MissingScriptEntry>();
    private int totalObjectsChecked;
    private int totalMissingScripts;

    [Serializable]
    private class MissingScriptEntry
    {
        public string displayText;
        public string assetPath;
        public string gameObjectPath;
        public bool isScene;
        public bool isHeader;

        public MissingScriptEntry(string text, string path = "", string objPath = "", bool scene = false, bool header = false)
        {
            displayText = text;
            assetPath = path;
            gameObjectPath = objPath;
            isScene = scene;
            isHeader = header;
        }
    }

    [MenuItem("Tools/Поиск потерянных скриптов")]
    public static void ShowWindow()
    {
        GetWindow<MissingScriptsFinder>("Поиск потерянных скриптов");
    }

    private void OnGUI()
    {
        GUILayout.Label("Поиск потерянных скриптов", EditorStyles.boldLabel);

        if (GUILayout.Button("Начать поиск во всех сценах и префабах", GUILayout.Height(40)))
        {
            FindMissingScriptsInProject();
        }

        if (GUILayout.Button("Очистить лог", GUILayout.Height(30)))
        {
            missingScriptsEntries.Clear();
            totalObjectsChecked = 0;
            totalMissingScripts = 0;
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Проверено объектов: {totalObjectsChecked}");
        EditorGUILayout.LabelField($"Найдено потерянных скриптов: {totalMissingScripts}");

        EditorGUILayout.Space();

        if (missingScriptsEntries.Count > 0)
        {
            GUILayout.Label("Результаты поиска:", EditorStyles.boldLabel);
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (var entry in missingScriptsEntries)
            {
                if (entry.isHeader)
                {
                    EditorGUILayout.LabelField(entry.displayText, EditorStyles.boldLabel);
                }
                else if (!string.IsNullOrEmpty(entry.assetPath))
                {
                    // Кликабельная запись с кнопкой выделения
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(entry.displayText, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));

                    if (GUILayout.Button("Выделить", GUILayout.Width(80)))
                    {
                        SelectObjectInProject(entry);
                    }

                    if (entry.isScene)
                    {
                        if (GUILayout.Button("Открыть", GUILayout.Width(80)))
                        {
                            OpenScene(entry.assetPath);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Открыть префаб", GUILayout.Width(100)))
                        {
                            OpenPrefab(entry.assetPath, entry.gameObjectPath);
                        }
                    }

                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.LabelField(entry.displayText, EditorStyles.wordWrappedLabel);
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }

    private void FindMissingScriptsInProject()
    {
        missingScriptsEntries.Clear();
        totalObjectsChecked = 0;
        totalMissingScripts = 0;

        Debug.Log("=== НАЧАЛО ПОИСКА ПОТЕРЯННЫХ СКРИПТОВ ===");
        missingScriptsEntries.Add(new MissingScriptEntry("=== НАЧАЛО ПОИСКА ПОТЕРЯННЫХ СКРИПТОВ ===", "", "", false, true));

        // Поиск в сценах
        FindMissingScriptsInScenes();

        // Поиск в префабах
        FindMissingScriptsInPrefabs();

        Debug.Log("=== ПОИСК ЗАВЕРШЕН ===");
        Debug.Log($"Всего проверено объектов: {totalObjectsChecked}");
        Debug.Log($"Всего найдено потерянных скриптов: {totalMissingScripts}");

        if (totalMissingScripts == 0)
        {
            Debug.Log("ПОЗДРАВЛЯЮ! Потерянных скриптов не найдено!");
            missingScriptsEntries.Add(new MissingScriptEntry("ПОЗДРАВЛЯЮ! Потерянных скриптов не найдено!"));
        }

        missingScriptsEntries.Add(new MissingScriptEntry("=== РЕЗУЛЬТАТЫ ПОИСКА ===", "", "", false, true));
        missingScriptsEntries.Add(new MissingScriptEntry($"Проверено объектов: {totalObjectsChecked}"));
        missingScriptsEntries.Add(new MissingScriptEntry($"Найдено потерянных скриптов: {totalMissingScripts}"));
        missingScriptsEntries.Add(new MissingScriptEntry(""));
    }

    private void FindMissingScriptsInScenes()
    {
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");

        foreach (string sceneGuid in sceneGuids)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);

            if (ShouldSkipPath(scenePath))
                continue;

            missingScriptsEntries.Add(new MissingScriptEntry($"--- ПРОВЕРКА СЦЕНЫ: {scenePath} ---", "", "", false, true));

            // Сохраняем текущую сцену
            Scene currentScene = EditorSceneManager.GetActiveScene();
            bool sceneWasDirty = currentScene.isDirty;

            // Открываем сцену в фоновом режиме
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);

            try
            {
                // Получаем все корневые объекты сцены
                GameObject[] rootObjects = scene.GetRootGameObjects();

                // Рекурсивно проверяем все объекты в сцене
                foreach (GameObject rootObject in rootObjects)
                {
                    CheckGameObjectAndChildren(rootObject, scenePath, true);
                }
            }
            finally
            {
                // Закрываем сцену без сохранения
                EditorSceneManager.CloseScene(scene, true);

                // Восстанавливаем предыдущую активную сцену
                if (sceneWasDirty && !string.IsNullOrEmpty(currentScene.path))
                {
                    EditorSceneManager.OpenScene(currentScene.path);
                }
            }

            missingScriptsEntries.Add(new MissingScriptEntry($"--- ЗАВЕРШЕНО: {scenePath} ---\n"));
        }
    }

    private void FindMissingScriptsInPrefabs()
    {
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");

        foreach (string prefabGuid in prefabGuids)
        {
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGuid);

            if (ShouldSkipPath(prefabPath))
                continue;

            missingScriptsEntries.Add(new MissingScriptEntry($"--- ПРОВЕРКА ПРЕФАБА: {prefabPath} ---", "", "", false, true));

            // Загружаем префаб
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            if (prefab != null)
            {
                // Создаем временный экземпляр префаба для проверки
                GameObject prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                if (prefabInstance != null)
                {
                    try
                    {
                        CheckGameObjectAndChildren(prefabInstance, prefabPath, false);
                    }
                    finally
                    {
                        // Уничтожаем временный экземпляр
                        DestroyImmediate(prefabInstance);
                    }
                }
            }

            missingScriptsEntries.Add(new MissingScriptEntry($"--- ЗАВЕРШЕНО: {prefabPath} ---\n"));
        }
    }

    private void CheckGameObjectAndChildren(GameObject gameObject, string assetPath, bool isScene)
    {
        totalObjectsChecked++;

        // Проверяем текущий объект на наличие потерянных скриптов
        CheckGameObjectForMissingScripts(gameObject, assetPath, isScene);

        // Рекурсивно проверяем всех детей
        foreach (Transform child in gameObject.transform)
        {
            CheckGameObjectAndChildren(child.gameObject, assetPath, isScene);
        }
    }

    private void CheckGameObjectForMissingScripts(GameObject gameObject, string assetPath, bool isScene)
    {
        Component[] components = gameObject.GetComponents<Component>();

        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] == null)
            {
                totalMissingScripts++;

                string locationType = isScene ? "СЦЕНА" : "ПРЕФАБ";
                string fullPath = GetGameObjectFullPath(gameObject);

                string message = $"[{locationType}] Обнаружен потерянный скрипт:\n" +
                               $"Место: {assetPath}\n" +
                               $"Объект: {fullPath}\n" +
                               $"Компонент #{i} на GameObject: {gameObject.name}";

                Debug.LogWarning(message);

                // Создаем запись с кликабельной ссылкой
                missingScriptsEntries.Add(new MissingScriptEntry(
                    message,
                    assetPath,
                    fullPath,
                    isScene
                ));

                // Добавляем информацию в консоль с кликабельной ссылкой
                Debug.Log($"<color=yellow>⚠️</color> <color=orange>Потерянный скрипт:</color> {assetPath} → {fullPath}", gameObject);
            }
        }
    }

    private void SelectObjectInProject(MissingScriptEntry entry)
    {
        if (string.IsNullOrEmpty(entry.assetPath))
            return;

        // Находим ассет в проекте
        UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(entry.assetPath);

        if (asset != null)
        {
            // Выделяем ассет в Project Window
            Selection.activeObject = asset;
            EditorGUIUtility.PingObject(asset);

            Debug.Log($"Выделен файл: {entry.assetPath}");
        }
        else
        {
            Debug.LogWarning($"Не удалось загрузить ассет: {entry.assetPath}");
        }
    }

    private void OpenScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
            Debug.Log($"Открыта сцена: {scenePath}");
        }
    }

    private void OpenPrefab(string prefabPath, string gameObjectPath)
    {
        // Загружаем префаб
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if (prefab != null)
        {
            // Открываем префаб в режиме редактирования
            AssetDatabase.OpenAsset(prefab);

            // Ищем GameObject в открытом префабе
            GameObject prefabInstance = PrefabUtility.GetOutermostPrefabInstanceRoot(prefab);

            if (prefabInstance != null && !string.IsNullOrEmpty(gameObjectPath))
            {
                // Пытаемся найти объект по пути
                Transform targetTransform = prefabInstance.transform.Find(gameObjectPath.TrimStart('/'));

                if (targetTransform != null)
                {
                    Selection.activeGameObject = targetTransform.gameObject;
                    EditorGUIUtility.PingObject(targetTransform.gameObject);
                }
                else
                {
                    // Если не нашли по пути, выделяем корневой объект
                    Selection.activeGameObject = prefabInstance;
                    EditorGUIUtility.PingObject(prefabInstance);
                }
            }

            Debug.Log($"Открыт префаб: {prefabPath}");
        }
        else
        {
            Debug.LogWarning($"Не удалось загрузить префаб: {prefabPath}");
        }
    }

    private string GetGameObjectFullPath(GameObject gameObject)
    {
        string path = gameObject.name;

        while (gameObject.transform.parent != null)
        {
            gameObject = gameObject.transform.parent.gameObject;
            path = gameObject.name + "/" + path;
        }

        return path;
    }

    private bool ShouldSkipPath(string path)
    {
        string[] skipKeywords =
        {
            "/Samples/",
            "/Samples~/",
            "/Example/",
            "/Examples/",
            "/Demo/",
            "/Demos/",
            "/Test/",
            "/Tests/",
            "Packages/",
            "/Editor/"
        };

        foreach (string keyword in skipKeywords)
        {
            if (path.Contains(keyword))
                return true;
        }

        return false;
    }

    // Дополнительный метод для поиска только в активной сцене
    [MenuItem("GameObject/Найти потерянные скрипты в выбранном объекте", false, 49)]
    private static void FindMissingScriptsInSelected()
    {
        GameObject selected = Selection.activeGameObject;

        if (selected == null)
        {
            Debug.LogWarning("Выберите GameObject для поиска потерянных скриптов");
            return;
        }

        int missingCount = 0;
        FindMissingRecursive(selected, ref missingCount);

        if (missingCount == 0)
        {
            Debug.Log($"В объекте {selected.name} и его детях не найдено потерянных скриптов");
        }
        else
        {
            Debug.Log($"В объекте {selected.name} и его детях найдено {missingCount} потерянных скриптов");
        }
    }

    private static void FindMissingRecursive(GameObject gameObject, ref int missingCount)
    {
        Component[] components = gameObject.GetComponents<Component>();

        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] == null)
            {
                missingCount++;
                string path = GetFullPathStatic(gameObject);
                Debug.LogWarning($"Потерянный скрипт #{i} на {path}", gameObject);
            }
        }

        foreach (Transform child in gameObject.transform)
        {
            FindMissingRecursive(child.gameObject, ref missingCount);
        }
    }

    private static string GetFullPathStatic(GameObject gameObject)
    {
        string path = gameObject.name;

        while (gameObject.transform.parent != null)
        {
            gameObject = gameObject.transform.parent.gameObject;
            path = gameObject.name + "/" + path;
        }

        return path;
    }
}