using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;
    private Rigidbody2D _rigidbody2D;
    private Vector3 velocity= Vector3.zero;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity =
            Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocity, _MovementSmoothing);


    }
    
}
