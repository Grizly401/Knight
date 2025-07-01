using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KnightEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IMover _mover;

    private void Update()
    {
        _mover.Update();
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove(); 
    }

}
