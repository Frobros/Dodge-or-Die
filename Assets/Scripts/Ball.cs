using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed,
        dragSpeed;
    public Player controlledBy;

    private PlayerController player1, player2;
    private Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right;
        player1 = Array.Find(FindObjectsOfType<PlayerController>(), p => p.player == Player.PLAYER_1);
        player2 = Array.Find(FindObjectsOfType<PlayerController>(), p => p.player == Player.PLAYER_2);
    }

    void Update()
    {
        Vector2 drag = Vector2.zero;
        if (controlledBy == Player.PLAYER_1)
        {
            drag = dragSpeed * player1.direction;
        }
        else if (controlledBy == Player.PLAYER_2)
        {
            drag = dragSpeed * player2.direction;
        }
        Vector2 velocity = rb.velocity + drag;
        rb.velocity = speed * velocity.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target t = collision.transform.GetComponent<Target>();
        if (t != null)
        {
            if (t.player == Player.PLAYER_1)
                controlledBy = Player.PLAYER_2;
            if (t.player == Player.PLAYER_2)
                controlledBy = Player.PLAYER_1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Target t = collision.transform.GetComponent<Target>();
        if (t != null)
        {
            controlledBy = Player.NONE;
        }
        PlayerController player = collision.transform.GetComponent<PlayerController>();
        if (player != null)
        {
            FindObjectOfType<Field>().SetPoint(player.player);
        }
    }
}
