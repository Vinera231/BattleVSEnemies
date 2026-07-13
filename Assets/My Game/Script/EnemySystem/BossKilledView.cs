using TMPro;
using UnityEngine;

public class BossKilledView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private EnemyBoss _enemyBoss;
    [SerializeField] private EnemyBossEasy _enemyBossEasy;

    private void OnEnable() =>
    UpdateInfo();

    private void UpdateInfo()
    {
        _text.text = _enemyBoss.BossKilled.ToString();
        _text.text = _enemyBossEasy.EasyBossKilled.ToString();
    }
}