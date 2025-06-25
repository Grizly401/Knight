using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 60)] private float _maxHeight;
    [SerializeField, Range(0, 60)] public float _timeToReachMaxHeight;

    public float StartYVelocity => 2 * _maxHeight / _timeToReachMaxHeight;
    public float MaxHeight => _maxHeight;
    public float TimeToReachMaxHeight => _timeToReachMaxHeight;

}
