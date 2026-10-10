using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable() =>
    _informer.Clicked += OnClick;

    private void OnDisable() =>
    _informer.Clicked -= OnClick;

    private void OnClick() =>
     SceneManager.LoadScene(1);
}
