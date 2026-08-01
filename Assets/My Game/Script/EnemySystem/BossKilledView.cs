using TMPro;
using UnityEngine;

public class BossKilledView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private EnemyBoss _enemyBoss;
    [SerializeField] private EnemyBossEasy _enemyBossEasy;
    [SerializeField] private KingBoss _enemyBossKing;

    private void OnEnable() =>
    UpdateInfo();

    private void UpdateInfo()
    {
        _text.text = _enemyBoss.BossKilled.ToString();
        _text.text = _enemyBossEasy.EasyBossKilled.ToString();
        _text.text = _enemyBossKing.KingBossKilled.ToString();
    }
}