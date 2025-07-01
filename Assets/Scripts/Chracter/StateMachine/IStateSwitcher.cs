using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateSwitcher
{
    void SwichState<State>() where State : IState;
}
