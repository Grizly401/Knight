using System;
using UnityEngine;

[Serializable]
public class RunnigStateConfig
{
    [field: SerializeField, Range(0, 20)] public float Speed { get; private set; }
}
