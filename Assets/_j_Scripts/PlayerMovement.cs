using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Player player;
    public Vector2 speed;

    internal Vector2 direction;
    
    
    public float freezeUntil = 0f,
        freezeFor;
    public bool isHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isHit)
            rb.velocity = speed * direction;
        else
        {
            rb.velocity = Vector2.zero;
            isHit = Time.time < freezeUntil;
        }
    }

    internal void Hit()
    {
        Debug.Log("FREEZE!");
        freezeUntil = Time.time + freezeFor;
        isHit = true;
        GetComponentInChildren<PlayerAnimate>().Hit();
    }
}
