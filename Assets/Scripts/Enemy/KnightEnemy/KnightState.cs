using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KnightState : MonoBehaviour
{
    [SerializeField] private Knight _knight;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private FOV _fov;
    [SerializeField] private ViewKnight _viewKnight; 
    [SerializeField] private float _speed;
    [SerializeField] private bool _patrol;

    private Transform[] precas;
    // Start is called before the first frame update'

    private void Awake()
    {
     
    }
    void Start()
    {
        _patrol = true;
        PatrolPoints();
    }

    // Update is called once per frame
    void Update()
    {
        precas = _fov.visibleTargets.ToArray();
         if (precas.Length > 0 && _patrol == false)
         {
            //StartCoroutine(StartPersecution());
            StartPersecution();
            _patrol = true;

        }
         else if(precas.Length == 0 && _patrol == true)
        {
            PatrolPoints(); 
            _patrol = false;
        }
    }

    private void PatrolPoints()
    {
        _knight.SetMover(new PointByPointMover(_knight.transform, _patrolPoints.Select(point => point.position), _speed, _knight.gameObject));
    }

    private void StartPersecution()
    {
        _knight.SetMover(new MoveToTargetPatern(_knight.transform, _fov.visibleTargets[0], _speed, _knight));
    }

}
