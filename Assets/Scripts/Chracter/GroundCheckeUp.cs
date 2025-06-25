using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckeUp : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    private CapsuleCollider2D _capsuleCollider2D;


    public bool IsTouchesGroundUp { get; private set; }
    // Start is called before the first frame update

    private void Update()
    {
        
    }

    void Start()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(IsTouchesGroundUp);
            IsTouchesGroundUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(IsTouchesGroundUp);
            IsTouchesGroundUp = false;
        }
    }
}
