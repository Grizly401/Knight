using System;
using UnityEngine;

[Serializable]
public class ClimbingConfig
{
    [field: SerializeField, Range(0, 40)] public float Speed { get; private set; }
}
