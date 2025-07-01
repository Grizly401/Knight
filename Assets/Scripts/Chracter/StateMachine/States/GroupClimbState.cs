using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupClimbState : MainState
{
    private GroudChecker _groundChecker;
    public GroupClimbState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _groundChecker = character.GroudChecker;

    public override void Enter()
    {
        base.Enter();
        Data.XVelocity = 0;
    }
    public override void HandleInput()
    {
        if(IsHorizontalInputZero())
                base.HandleInput();

        Data.YIput = ReadVerticalInput();
        Data.YVelocity = Data.YIput * Data.Speed;
    }

    public override void Update()
    {
        base.Update();
        SetHorizontalInputZero();
        Data.YVelocity = ReadVerticalInput();
        Vector2 velocity = GetConvertedVelocity();
        RB.MovePosition(RB.position + velocity * Time.fixedDeltaTime);
    }

    private Vector2 GetConvertedVelocity() => new Vector2(Data.XVelocity, Data.YVelocity);

    private float ReadVerticalInput() => Input.Movement.Climb.ReadValue<float>();

}
