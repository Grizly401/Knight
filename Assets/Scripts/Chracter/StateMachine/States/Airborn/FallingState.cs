using UnityEngine;

public class FallingState : AirborneState
{
    private readonly GroudChecker _groudChecker;
    private readonly JumpingStateConfig _config;
    private readonly Character _character;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groudChecker = character.GroudChecker; 
        _config = character.Config.AirborneStateConfig.JumpingStateConfig;
        _character = character;
    } 


    public override void Enter()
    {
        base.Enter();
        View.StartFalling();
        _character.BoxColider.JumpBox();

    }

    public override void Update()
    {
        base.Update();

        if (_groudChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
                StateSwitcher.SwichState<IdlingState>();
            else
                StateSwitcher.SwichState<RunningState>();
        }

    }

    public override void Exit()
    {
        base.Exit();
        View.StopFalling();

       /* if(_groudChecker.IsTouches)
            AudioManager.Instance.PlaySFX("Fall");*/
    }
}
