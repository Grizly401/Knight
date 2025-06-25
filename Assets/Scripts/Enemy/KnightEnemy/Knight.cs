using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private ViewKnight _viewKnight;

    private float _speed;
    private IMover _mover;
    private CircleCollider2D _circleCollider2D;

    public ViewKnight viewKnight => _viewKnight;
    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mover.Update();

    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DataGame.GetInctance().IsDead = true;
        }
    }
}
