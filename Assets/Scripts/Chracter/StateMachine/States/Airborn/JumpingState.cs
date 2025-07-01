using UnityEngine;
public class JumpingState : AirborneState
{
    private readonly JumpingStateConfig _config;
    private readonly GroudChecker _groundChecker;
    private readonly Character _character;
    private float _timeJump;
    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirborneStateConfig.JumpingStateConfig;
        _groundChecker = character.GroudChecker;
        _character = character;
    }

    public override void Enter()
    {
        base.Enter();
        View.StartJumping();
        Data.YVelocity = _config.StartYVelocity;
        //AudioManager.Instance.PlaySFX("Jump");
        _character.BoxColider.JumpBox();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity <= 0)
            StateSwitcher.SwichState<FallingState>();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopJumping();
    }
}
