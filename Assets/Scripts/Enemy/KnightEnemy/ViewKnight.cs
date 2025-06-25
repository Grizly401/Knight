using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ViewKnight : MonoBehaviour
{
    private Animator _animator;
    private Transform _transform;

    private const string IsPatrol = "IsPatrol";
    private const string IsPersecution = "IsPersecution";
    private const string IsFind = "IsFind";
    private const string IsIdle = "IsIdle";

    private Quaternion TurnLeft => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnRight => Quaternion.Euler(0, 180, 0);


    private void Start()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        StartPatrol();
    }

    public void StartPatrol() => _animator.SetBool(IsPatrol, true);
    public void StopPatrol() => _animator.SetBool(IsPatrol, false);

    public void StartPersecution() => _animator.SetBool(IsPersecution, true);
    public void StopPersecution() => _animator.SetBool(IsPersecution, false);
    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);
    public void StartFind() => _animator.SetBool(IsFind, true);
    public void StopFind() => _animator.SetBool(IsFind, false);
    public bool GetPersecution() => _animator.GetBool(IsPersecution);
    public Quaternion ChangeRotation(Vector2 VectorToTarget, GameObject turnObject)
    {
      if(VectorToTarget.x > 0)
        {
            return gameObject.transform.rotation = TurnRight;
        }
      else
        {
            return gameObject.transform.rotation = TurnLeft;
        }
    }


}
