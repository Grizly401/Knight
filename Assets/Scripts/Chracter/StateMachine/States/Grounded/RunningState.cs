using UnityEngine;

public class RunningState : GroundedState
{
    private RunnigStateConfig _config;
    private readonly GroudChecker _groudChecker;
    private readonly Character _character;
    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groudChecker = character.GroudChecker;
        _config = character.Config.RunnigStateConfig;
        _character = character;
    }
   

    public override void Enter()
    {
        base.Enter();
        View.StartRunnig();
        _character.BoxColider.IdleBox();
        Data.Speed = _config.Speed;
    }
    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwichState<IdlingState>();

        if (Input.Movement.Crawl.IsPressed())
            StateSwitcher.SwichState<CrawlState>();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopRunnig();
    }
}
