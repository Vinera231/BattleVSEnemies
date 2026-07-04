using UnityEngine;

public class EncyclopediaNextButton : ButtonInformer
{
    [SerializeField] private Encyclopedia _encyclopedia;

    protected override void OnClick()
    {
        base.OnClick();

        _encyclopedia.Next();
    }
}