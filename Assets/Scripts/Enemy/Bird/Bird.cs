using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _patrolPoints;

    private PointByPointMover _mover;

    void Start()
    {
        _mover = new PointByPointMover(transform, _patrolPoints.Select(point=>point.position), _speed, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _mover.Update();
    }
}
