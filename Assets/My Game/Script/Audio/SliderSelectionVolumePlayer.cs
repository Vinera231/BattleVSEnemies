using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderSelectionVolumePlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;

    private void Awake() =>
        _wait = new(_delay);

    public void OnPointerUp(PointerEventData eventData) =>
        StopCoroutine();

    public void OnPointerDown(PointerEventData eventData) =>
        StartCoroutine();

    private void StartCoroutine()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(Routine());
    }

    private void StopCoroutine()
    {
        Debug.Log("StopCoroutine");
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Routine()
    {
        while (true)
        {
            _sfx.PlaySettingSound();
            Debug.Log(nameof(Routine));
            yield return _wait;
        }
    }
}