using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuAnimationPlay : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetTrigger("SwipeButtonPlay");
    }

}
