using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ViewKnight : MonoBehaviour
{
    private Animator _animator;

    private const string IsPatrol = "IsPatrol";
    private const string IsPersecution = "IsPersecution";
    private const string IsFind = "IsFind";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartPatrol() => _animator.SetBool(IsPatrol, true);
    public void StopPatrol() => _animator.SetBool(IsPatrol, false);

    public void StartPersecution() => _animator.SetBool(IsPersecution, true);
    public void StopPersecution() => _animator.SetBool(IsPersecution, false);
    public void StartFind() => _animator.SetBool(IsFind, true);
    public void StopFind() => _animator.SetBool(IsFind, false);
}
