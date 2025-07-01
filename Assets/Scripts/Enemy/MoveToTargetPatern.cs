using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetPatern : IMover
{
    private Transform  _transform;
    private Transform _target;
    private float _speed;
    private Knight _knight;

    private bool _isMoving;

    public MoveToTargetPatern(Transform transform, Transform target, float speed, Knight knight)
    {
        _transform = transform;
        _target = target;
        _speed = speed;
        _knight = knight;
    }

    public void StartMove()
    {
        _isMoving = true;
        _knight.viewKnight.StartFind();
        _knight.viewKnight.StopFind();
        _knight.viewKnight.StartPersecution();
    }

    public void StopMove()
    {
        _isMoving = false;
        _knight.viewKnight.StopPersecution();
    }

    public void Update()
    {
        if (_isMoving == false)
            return;

        float direction = _target.position.x - _transform.position.x;
        _transform.Translate(new Vector2(_target.position.x - _transform.position.x, 0).normalized * _speed * Time.deltaTime);
    }
}
