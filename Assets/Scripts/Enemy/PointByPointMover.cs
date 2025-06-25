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
    private Transform[] _precas;
    private Vector2 direction;

    private Quaternion TurnLeft => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnRight => Quaternion.Euler(0, 180, 0);
    private Vector3 _currentTarget;

    public PointByPointMover(Transform transform, IEnumerable<Vector3> targets, float speed, GameObject animObject)
    {
        _transform = transform;
        _targets = new Queue<Vector3>(targets);
        _speed = speed;
        _object = animObject;
        _currentTarget = _targets.Dequeue();
    }

    public PointByPointMover(Transform transform, IEnumerable<Vector3> targets, float speed, GameObject animObject, Knight knight)
    {
        _transform = transform;
        _targets = new Queue<Vector3>(targets);
        _speed = speed;
        _object = animObject;
        _knight = knight;

        _currentTarget = _targets.Dequeue();
    }

    public void Update()
    {
        direction = _currentTarget - _transform.position;
        _transform.Translate(direction.normalized * _speed * Time.deltaTime);

        if (direction.magnitude <= MinDistanceToTarget)
        {
            SwitchTarget();
            GetRotationFrom(_object);
        }


    }
    public Quaternion GetRotationFrom(GameObject gameObject)
    {
        
        if (LookRight == false && _currentTarget.x > _transform.position.x)
        {
            LookRight = true;
            return gameObject.transform.rotation = TurnRight;
        }
        else
        {
            LookRight = false;
            return gameObject.transform.rotation = TurnLeft;
        }

    }

    private void SwitchTarget()
    {
        _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
        
    }

    public void StartMove()
    {

        Debug.Log("Work?StartMove");
        _knight.viewKnight.StartPatrol();
        GetRotationFrom(_object);
    }

    public void StopMove()
    {

        Debug.Log("Work?StopMove");
        _knight.viewKnight.StopPatrol();
    }
}
