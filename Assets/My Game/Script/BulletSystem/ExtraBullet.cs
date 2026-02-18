public class ExtraBullet : Bullet
{
    protected override void OnTriggerEnter(UnityEngine.Collider other) =>
        base.OnTriggerEnter(other);   
}