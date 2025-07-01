using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointByPointMover : IMover
{
    private const float MinDistanceToTarget = 1f;

    private Transform _transform;
    private Queue<Vector3> _targets;
    private float _speed;
    private GameObject _object;
    private bool LookRight;
    private Knight _knight;

    private Quaternion TurnLeft => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnRight => Quaternion.Euler(0, 180, 0);
    private Vector3 _currentTarget;

    public PointByPointMover(Transform transform, IEnumerable<Vector3> targets, float speed, GameObject enemuObject)
    {
        _transform = transform;
        _targets = new Queue<Vector3>(targets);
        _speed = speed;
        _object = enemuObject;

        _currentTarget = _targets.Dequeue();
    }

    public PointByPointMover(Transform transform, IEnumerable<Vector3> targets, float speed, GameObject enemuObject, Knight knight)
    {
        _transform = transform;
        _targets = new Queue<Vector3>(targets);
        _speed = speed;
        _object = enemuObject;
        _knight = knight;

        _currentTarget = _targets.Dequeue();
    }

    public void Update()
    {
        Vector2 direction = _currentTarget - _transform.position;
        _transform.Translate(direction.normalized * _speed * Time.deltaTime);

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();

    }
    public Quaternion GetRotationFrom(GameObject gameObject)
    {
        if (LookRight == false)
        {
            LookRight = true;
            return gameObject.transform.GetChild(0).rotation = TurnRight;
        }
        else
        {
            LookRight = false;
            return gameObject.transform.GetChild(0).rotation = TurnLeft;
        }

    }

    private void SwitchTarget()
    {
        _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
        GetRotationFrom(_object);
    }

    public void StartMove()
    {
        if(_knight != null)
        {
            _knight.viewKnight.StartPatrol();
        }
    }

    public void StopMove()
    {
        if (_knight != null)
        {
            _knight.viewKnight.StopPatrol();
        }
    }
}
