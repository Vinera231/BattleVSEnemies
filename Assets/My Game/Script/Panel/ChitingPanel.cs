using System;
using UnityEngine;

public class ChitingPanel : MonoBehaviour
{
    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}