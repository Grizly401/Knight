using UnityEngine;

public class DieState : MovementState
{
    private Character _character;
    private float _pulseRight;
    private float _pulseLeft;
    public DieState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _character = character;

    public override void Enter()
    {
        base.Enter();
        ChangeCollider();
        AudioManager.Instance.PlaySFX("Die");
        if (true)
        {
            RB.AddForce(RB.transform.right * -5f, ForceMode2D.Impulse);
        }
        View.StartDie();
    }

    public override void Update()
    {
       
    }

    public void ChangeCollider()
    {
        _character.GetComponent<BoxCollider2D>().offset = new Vector2(-0.4f, 0.3f);
        _character.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 0.79f);
    }

}
