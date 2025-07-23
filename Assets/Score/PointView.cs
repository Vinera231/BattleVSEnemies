using UnityEngine;
using UnityEngine.UI;

public class PointView : MonoBehaviour
{
    [SerializeField] private Text _text;

   public void ShowPoint(int score)
    {
        _text.text = $"{score}";
    }

}
