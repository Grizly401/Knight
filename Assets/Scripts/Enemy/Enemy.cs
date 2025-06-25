using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage(collision);
            Debug.Log("Work");
        }
    }

    private void Damage(Collider2D collision)
    {
        /* if(collision.GetComponent<Character>().Characteristic.Health <= 0)
             StartCoroutine(_dataGame.EndGame());   
         else*/
        //collision.GetComponent<Character>(). = 0;

        DataGame.GetInctance().IsDead = true;
    }
}
