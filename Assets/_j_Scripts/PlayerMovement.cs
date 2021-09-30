using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Player player;
    public Vector2 speed;

    internal Vector2 direction;
    
    
    public float freezeUntil = 0f,
        freezeFor,
        damping;
    public bool isHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isHit)
        {
            rb.velocity = speed * direction;
        }
        else
        {
            isHit = Time.time < freezeUntil;
            rb.velocity = rb.velocity * Damp(damping);
        }
    }

    internal void Hit(Vector3 position)
    {
        Vector2 hitDirection = transform.position - position;
        rb.velocity = Vector2.zero;
        rb.AddForce(10f * hitDirection, ForceMode2D.Impulse);
        freezeUntil = Time.time + freezeFor;
        isHit = true;
        GetComponentInChildren<PlayerAnimate>().Hit(-hitDirection);
    }

    private float Damp(float dampingFactor)
    {
        return Mathf.Pow(1f - dampingFactor, Time.deltaTime);
    }
}