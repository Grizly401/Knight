using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();
        _states = new List<IState>()
        {
            new IdlingState(this, data, character),
            new RunningState(this, data, character),
            new JumpingState(this, data, character),
            new FallingState(this, data, character),
            new DieState(this, data, character),
            new ClimbState(this, data, character),
            new ClimbingState(this, data, character),
            new CrawlState(this, data, character),
             new IdleCrawlState(this, data, character),
    };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwichState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
