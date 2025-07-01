using UnityEngine;

public abstract class AirborneState : MovementState
{
    private readonly AirborneStateConfig _config;
    private readonly GroudChecker _groundChecker;
    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    { 
        _config = character.Config.AirborneStateConfig;
        _groundChecker = character.GroudChecker;

} 

    public override void Enter()
    {
        base.Enter();
        //_groundChecker.BoxColliderChecker.enabled = true;
        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();
        Data.YVelocity -= _config.BaseGravity * Time.deltaTime;

        if (_groundChecker.IsTouchesLadder && Input.Movement.Climb.IsPressed() && Input.Movement.Jump.IsPressed() == false)
            StateSwitcher.SwichState<ClimbState>();
    }

    public override void Exit()
    {
        base.Exit();
        //_groundChecker.BoxColliderChecker.enabled = false;
    }
}
