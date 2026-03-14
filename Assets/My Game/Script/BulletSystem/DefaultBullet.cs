
public class DefaultBullet : Bullet
{
    public override void OnShot() =>
         SfxPlayer.Instance.PlayShootSound();
}