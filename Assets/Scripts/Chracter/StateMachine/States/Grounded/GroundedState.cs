using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private readonly GroudChecker _groundChecker;
    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _groundChecker = character.GroudChecker;

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        /*if (Input.Movement.Jump.IsPressed())
            StateSwitcher.SwichState<JumpingState>();*/

        if (_groundChecker.IsTouches == false && _groundChecker.IsTouchesLadder == false)
            StateSwitcher.SwichState<FallingState>();

        if (_groundChecker.IsTouchesLadder && Input.Movement.Climb.IsPressed())
            StateSwitcher.SwichState<ClimbState>();
    }
    protected override void AddInputActionCallBack()
    {
        base.AddInputActionCallBack();

        Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    protected override void RemoveInputActionCallBack()
    {
        base.RemoveInputActionCallBack();
        Input.Movement.Jump.started -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj)
    {
        StateSwitcher.SwichState<JumpingState>();
    }

    private float ReadJumpInput() => Input.Movement.Jump.ReadValue<float>();
}
