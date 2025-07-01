using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanPlayer : MonoBehaviour
{

    public float distance;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.right, Color.black, distance); 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Scaning(collision.gameObject.transform);
        }
    }
        
    private void Scaning(Transform target)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, transform.right, distance);
        for (int i = 0; i < hit.Length; i++)
        {
            RaycastHit2D punch = hit[i];
            Debug.Log(punch.collider);
        }
       /* if (hit)
        {
            Debug.Log(hit.collider);
            Debug.DrawRay(transform.position, target.position, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, target.position, Color.blue);
        }*/
    }

    /*  public float fovAngle = 60f;
      public float fovRange = 3f;
      public Vector2 lookDirection = Vector2.down;

      private CapsuleCollider2D _capsuleCollider;

      void Start()
      {
          _capsuleCollider = GetComponent<CapsuleCollider2D>();
      }

      // Update is called once per frame
      void Update()
      {

      }

      private void OnTriggerStay2D(Collider2D collision)
      {
          if (collision.gameObject.tag == "Player")
          {
              if (IsTargetInsideFOV(collision.gameObject.transform))
              {
                  Debug.Log("Вижу петуха");
              }
          }
      }

      public bool IsTargetInsideFOV(Transform target)
      {
          Vector2 directionToTarget = (target.position - transform.position).normalized;
          float angelToTarget = Vector2.Angle(lookDirection, directionToTarget);

          if (angelToTarget < fovAngle / 2)
          {
              float distance = Vector2.Distance(target.position, transform.position);

              return distance < fovRange;
          }
          else
              return false;

      }*/
}
