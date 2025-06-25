using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetPatern : IMover
{
    private Transform  _transform;
    private Transform _target;
    private float _speed;
    private Knight _knight;
    private Transform[] _precas;
    private bool _isMoving;
    private FOV _fov;
    private GameObject _animObject;

    public MoveToTargetPatern(Transform transform, Transform target, float speed, Knight knight, FOV fOV, GameObject animObject)
    {
        _transform = transform;
        _target = target;
        _speed = speed;
        _knight = knight;
        _fov = fOV;
        _animObject = animObject;
    }

    public void StartMove()
    {
        _isMoving = true;
        _knight.viewKnight.StartFind();
        _speed += 10;
        _knight.viewKnight.ChangeRotation(_fov.dirTarget, _animObject);
        //_knight.viewKnight.StartPersecution();
    }

    public void Update()
    {
        while (!_knight.viewKnight.GetPersecution())
        {
            return;
        }

        float direction = _target.position.x - _transform.position.x;
        _transform.Translate(new Vector2(_target.position.x - _transform.position.x, 0).normalized * _speed * Time.deltaTime);
    }
    public void StopMove()
    {
        _isMoving = false;
        _knight.viewKnight.StopPersecution();
    }
}
