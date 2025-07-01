using UnityEngine;

public class ClimbState : GroupClimbState
{
    private Character _character;
    private readonly GroudChecker _groundCheker;
    public ClimbState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _character = character;
        _groundCheker = character.GroudChecker;
    }

    public override void Enter()
    {
        base.Enter();
        View.StartClimb();
        _character.RB.bodyType = RigidbodyType2D.Kinematic;
    }

   /* public override void HandleInput()
    {
        base.HandleInput();
       /* Data.YIput = ReadVerticalInput();
        Data.YVelocity = Data.YIput * Data.Speed;
    } */

    public override void Update()
    {
        base.Update();

        if (Input.Movement.Jump.IsPressed())
            StateSwitcher.SwichState<JumpingState>();

        if (IsVerticalInputZero() == false)
            StateSwitcher.SwichState<ClimbingState>();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopClimb();
        _character.RB.bodyType = RigidbodyType2D.Dynamic;
    }

    //private float ReadVerticalInput() => Input.Movement.Climb.ReadValue<float>();
}
