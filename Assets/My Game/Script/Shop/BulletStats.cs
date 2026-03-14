using System;

[Serializable]
public class BulletStats
{
    public float Rate;
    public int Limit;
    public float StartBullet;

    public BulletStats(float rate, int limit, float startBullet = 0)
    {
        Rate = rate;
        Limit = limit;
        StartBullet = startBullet;
    }
}