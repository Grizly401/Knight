using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = new Vector2(_transform.position.x - _speed * Time.deltaTime, _transform.position.y);
    }
}
