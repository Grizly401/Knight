using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GameObject _checker;
    [SerializeField] private CharacterConfig _config;

    private CharacterBoxColider _boxColider;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private Rigidbody2D _rb;

    public CharacterConfig Config => _config;
    public GroudChecker GroudChecker => _checker.GetComponent<GroudChecker>();
    public CharacterView View => _view;
    public PlayerInput Input => _input;
    public Rigidbody2D RB => _rb;
    public CharacterBoxColider BoxColider => _boxColider;

    private void Awake()
    {
        _boxColider = new CharacterBoxColider(this);
        _rb = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    //private float ReadJumpInput() => Input.Movement.Jump.ReadValue<float>();
}
