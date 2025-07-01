using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCrawlState : GroundedState
{
    readonly private Character _character;

    public IdleCrawlState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _character = character;

    public override void Enter()
    {
        base.Enter();
        View.StartCrawlIng();
        _character.BoxColider.CrawlBox();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(_character.Input.Movement.Crawl.IsPressed());
        if (_character.Input.Movement.Crawl.IsPressed() == false)
        {
            if (IsHorizontalInputZero())
                StateSwitcher.SwichState<IdlingState>();
            else
                StateSwitcher.SwichState<RunningState>();
        }
        else if (IsHorizontalInputZero() == false && _character.Input.Movement.Crawl.IsPressed() == true)
        {
            StateSwitcher.SwichState<CrawlState>();
        }
    }

    public override void Exit()
    {
        base.Exit();
        View.StopCrawlIng();
    }
}
