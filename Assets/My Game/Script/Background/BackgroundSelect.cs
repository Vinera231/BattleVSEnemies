using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSelect : MonoBehaviour
{
    [SerializeField] private List <Button> _select;
    [SerializeField] private List <GameObject> _backGround;
    [SerializeField] private List <GameObject> _backGroundFrame;

    private int _index;
    private bool _isOn;

    private void OnEnable()
    {
        _select[_index].onClick.AddListener(Show);
    }

    private void OnDisable()
    {
        _select[_index].onClick.RemoveListener(Show);
    }

    private void Show()
    {
        _isOn =! _isOn;

        _backGround[_index].SetActive(_isOn);
        _backGroundFrame[_index].SetActive(_isOn);
    }
}
