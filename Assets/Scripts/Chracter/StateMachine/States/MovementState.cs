using UnityEngine;

public abstract class MainState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    private readonly Character _character;

    protected bool _isClimb = false;
    
    private DataGame _dataGame;

    protected CharacterView View => _character.View;
    protected PlayerInput Input => _character.Input;
    protected Rigidbody2D RB => _character.RB;

    protected MainState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        Data = data;
        StateSwitcher = stateSwitcher;
        _character = character;
    }

    public virtual void Enter()
    {
        //Debug.Log(GetType());
        AddInputActionCallBack();
    }

    public virtual void Exit()
    {
        RemoveInputActionCallBack();
    }

    public virtual void HandleInput()
    {

    }

    public virtual void Update()
    {
   
        if (DataGame.GetInctance().IsDead)
        {
            StateSwitcher.SwichState<DieState>();
        }
    }

    protected virtual void AddInputActionCallBack()
    {

    }
    protected virtual void RemoveInputActionCallBack()
    {

    }

    protected float SetHorizontalInputZero() => Data.XIput = 0;
    protected bool IsHorizontalInputZero() => Data.XIput == 0;
    protected bool IsVerticalInputZero() => Data.YIput == 0;
  
    }

  
