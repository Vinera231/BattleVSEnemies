using System;
using TMPro;
using UnityEngine;

public class TriggerCude : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI;

    public bool IsActive => _shopUI.gameObject.activeInHierarchy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _shopUI.SetActive(true);         
            Debug.Log("����� ����� � ����");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _shopUI.SetActive(false);
            Debug.Log("����� ����� �� ����");
        }
    }
} 
