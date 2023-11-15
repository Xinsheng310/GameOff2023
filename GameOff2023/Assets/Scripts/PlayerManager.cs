using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D      rigidbody;
    [HideInInspector] public CircleCollider2D colloder;
    
    [HideInInspector] public Vector3 Pos
    {
        get { return transform.position; }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        colloder  = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRigidbody()
    {
        rigidbody.isKinematic = false;
    }

    public void DeactivateRigidbody()
    {
        rigidbody.velocity        = Vector3.zero;
        rigidbody.angularVelocity = 0f;
        rigidbody.isKinematic     = true;
    }
}
