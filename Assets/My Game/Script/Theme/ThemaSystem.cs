using System;
using UnityEngine;
using UnityEngine.UI;

public class ThemaSystem : MonoBehaviour
{
    [SerializeField] private Material[] _materialTimeofDay;
    [SerializeField] private Material[] _materialSkyBox;
    [SerializeField] private Light _light;

    [Header("Theme UI")]
    [SerializeField] private Toggle[] _toggles;
    [SerializeField] private GameObject[] _themePanels;

    private void Awake()
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            int index = i;
            _toggles[i].onValueChanged.AddListener(isOn => OnThemeSelected(index, isOn));

            bool isUnlock = SaverSystem.isUnlocked(i);
            _themePanels[i].SetActive(isUnlock);
        }

        int selectedIndex = SaverSystem.GetSelectTheme();

        if(selectedIndex < 0 || selectedIndex >= _themePanels.Length|| SaverSystem.isUnlocked(selectedIndex)== false)
            selectedIndex = 0;

        _toggles[selectedIndex].isOn = true;
        ApplyThemes(selectedIndex);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            _toggles[i].onValueChanged.RemoveListener(isOn =>OnThemeSelected(i,isOn));
        }
    }

    private void OnThemeSelected(int index, bool isOn)
    {
        if (isOn == false)
            return;

        ApplyThemes(index);
        SaverSystem.Select(index);
    }

    private void ApplyThemes(int index)
    {
        if (index < 0 || index >= _materialTimeofDay.Length)
            return;

        if (_materialSkyBox[index] == null)
            return;

        RenderSettings.skybox = _materialSkyBox[index];

        if (_materialTimeofDay.Length > index && _materialTimeofDay[index] != null)
            _light.color = _materialTimeofDay[index].color;

        DynamicGI.UpdateEnvironment();
    }
}