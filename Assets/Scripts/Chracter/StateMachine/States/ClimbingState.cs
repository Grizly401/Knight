using UnityEngine;

public class ClimbingState : GroupClimbState
{
    private Character _character;
    private readonly GroudChecker _groundCheker;
    public ClimbingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _character = character;
        _groundCheker = character.GroudChecker;
    }

    public override void Enter()
    {
        base.Enter();
        SetHorizontalInputZero();
        View.StartClimbing();
        _character.RB.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void Update()
    {
        base.Update();

        if (Input.Movement.Jump.IsPressed())
            StateSwitcher.SwichState<JumpingState>();

        if (_groundCheker.IsTouchesLadder == false)
            StateSwitcher.SwichState<IdlingState>();

        if (IsVerticalInputZero())
            StateSwitcher.SwichState<ClimbState>();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopClimbing();
        _character.RB.bodyType = RigidbodyType2D.Dynamic;
    }


}
