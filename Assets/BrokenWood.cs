using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWood : MonoBehaviour
{

    private BoxCollider2D _box;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Broken(0.8f));
        }
    }

    private IEnumerator Broken(float TimeToBroken)
    {
        _animator.SetBool("Broken", true);
        yield return new WaitForSeconds(TimeToBroken);
        _box.enabled = false;
        yield return new WaitForSeconds(TimeToBroken);
        Destroy(gameObject);
    }
}
