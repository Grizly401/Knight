using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : MainState
{

    public Vector2 Velocity { get; set; }

    private Character _character;
    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);
    

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _character = character;
    }


    public override void Update()
    {
        base.Update();

        Velocity = GetConvertedVelocity();
        RB.MovePosition(RB.position + Velocity * Time.fixedDeltaTime);
        _character.transform.rotation = GetRotationFrom(Velocity);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        Data.XIput = ReadHorizontalInput();
        Data.XVelocity = Data.XIput * Data.Speed;
    }

    private Quaternion GetRotationFrom(Vector2 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return _character.transform.rotation;
    }

    private Vector2 GetConvertedVelocity() => new Vector2(Data.XVelocity, Data.YVelocity);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
