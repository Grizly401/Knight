using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlState : GroundedState
{
    readonly private Character _character;
    public CrawlState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _character = character;

    public override void Enter()
    {
        base.Enter();
        View.StartCrawl();
        _character.BoxColider.CrawlBox();
    }

    public override void Update()
    {
        base.Update();

        if(_character.Input.Movement.Crawl.IsPressed() == false)
        {
            if (IsHorizontalInputZero())
                StateSwitcher.SwichState<IdlingState>();
            else
                StateSwitcher.SwichState<RunningState>();
        }
        else if (IsHorizontalInputZero() && _character.Input.Movement.Crawl.IsPressed())
        {
            StateSwitcher.SwichState<IdleCrawlState>();
        }
             


        /*if (IsHorizontalInputZero())
            StateSwitcher.SwichState<IdlingState>();
        else
            StateSwitcher.SwichState<RunningState>();*/
    }

    public override void Exit()
    {
        base.Exit();
        View.StopCrawl();
    }
}
