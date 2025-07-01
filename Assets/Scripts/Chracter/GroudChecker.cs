using UnityEngine;

public class GroudChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField, Range(0.01f, 1f)] private float _distanceToCheck;
    [SerializeField] Vector3 _distance; 

    private CapsuleCollider2D _capsuleCollider2D;
   // private BoxCollider2D _boxCollider2D;

   // public BoxCollider2D BoxColliderChecker => _boxCollider2D;

    private void Awake()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
       // _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool IsTouches { get; private set; }
    public bool IsTouchesLadder { get; private set; }


    public void ChangePosition()
    {

    }

    private void Update()
    {
        //IsTouches = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
        //Debug.Log(IsTouches);
        //transform.position = _distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(IsTouches);
            IsTouches = true;
        }

        if (collision.gameObject.tag == "Ladder")
        {
            Debug.Log(IsTouchesLadder);
            IsTouchesLadder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(IsTouches);
            IsTouches = false;
        }

        if (collision.gameObject.tag == "Ladder")
        {
            Debug.Log(IsTouchesLadder);
            IsTouchesLadder = false;
        }
    }

    

}
