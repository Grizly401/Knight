public class IdlingState : GroundedState
{
    private readonly GroudChecker _groudChecker;
    private readonly Character _character;
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groudChecker = character.GroudChecker;
        _character = character;
    }

    public override void Enter()
    {
        base.Enter();
        View.StartIdling();
        _character.BoxColider.IdleBox();
    }
    public override void Update()
    {
        base.Update();

        if (Input.Movement.Crawl.IsPressed())
            StateSwitcher.SwichState<CrawlState>();
        
        if (IsHorizontalInputZero())
            return;
       
            StateSwitcher.SwichState<RunningState>();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopIdling();
    }
}
