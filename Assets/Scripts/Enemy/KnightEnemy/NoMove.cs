using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMove : IMover
{
    private float _speed;
    private ViewKnight _viewKnight;

    public NoMove(float speed, Knight knight)
    {
        _speed = speed;
        _viewKnight = knight.viewKnight;
    }

    public void StartMove()
    {
        _viewKnight.StartIdle();
        _speed = 0;
    }

    public void Update()
    {

    }

    public void StopMove()
    {
        _viewKnight.StopIdle();
    }

}
