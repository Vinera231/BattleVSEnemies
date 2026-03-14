public class ExtraBullet : Bullet
{
    public override void OnShot() =>    
        SfxPlayer.Instance.PlayLaserSound();
    
    protected override void OnTriggerEnter(UnityEngine.Collider other) =>
        base.OnTriggerEnter(other);   
}