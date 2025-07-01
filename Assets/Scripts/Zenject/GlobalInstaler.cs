using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GlobalInstaler : MonoInstaller
{

    public override void InstallBindings()
    {
        BuildKnightState();
    }

    private void BuildKnightState()
    {
        Container.Bind<FOV>().NonLazy();
    }
}
