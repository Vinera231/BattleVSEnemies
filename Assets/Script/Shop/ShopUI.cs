using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public partial class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopPage[] _pages;
    [SerializeField] private ButtonInformer _nextArrow;
    [SerializeField] private ButtonInformer _backArrow;

    private int _pageIndex = 0;

    private void OnEnable()
    {
        _nextArrow.Clicked += NextPage;
        _backArrow.Clicked += PrevPage;
    }

    private void OnDisable()
    {
        _nextArrow.Clicked -= NextPage;
        _nextArrow.Clicked -= PrevPage;
    }

    private void Start() =>
    ShowPage(_pageIndex);

    public void ShowPage(int index)
    {
        for(int i = 0; i < _pages.Length; i++)
        {
            bool active = (i == index);
            _pages[1]._iteamsContainer.gameObject.SetActive(index > 0);
            _pages[1]._infoText.gameObject.SetActive(index< _pages.Length - 1);
        }
    }

    public void NextPage()
    {
        if(_pageIndex < _pages.Length -1)
        {
            _pageIndex++;
            ShowPage(_pageIndex);
        }
    }

    public void PrevPage()
    {
        if (_pageIndex > 0)
        {
            _pageIndex--;
            ShowPage(_pageIndex);
        }
    }
}