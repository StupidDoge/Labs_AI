using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _body.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
            _body.velocity = new Vector2(_body.velocity.x, _speed);
    }
}
