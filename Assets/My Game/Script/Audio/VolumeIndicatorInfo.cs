using System;
using UnityEngine;

[Serializable]
public class VolumeIndicatorInfo
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _lowerThreshold;

    public Sprite Sprite => _sprite;

    public float LowerThreshold => _lowerThreshold;
}