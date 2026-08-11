using UnityEngine;

public class EncyclopediaPreviousButton : ButtonInformer
{
    [SerializeField] private Encyclopedia _encyclopedia;
   
    protected override void OnClick()
    {
        base.OnClick();

        _encyclopedia.Previous();      
    }
}