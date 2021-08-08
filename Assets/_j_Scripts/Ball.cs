using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed,
        dragSpeed;
    public Player controlledBy;
    public Material matPlayer1, matPlayer2, matBoth, matNone;
    private PlayerMovement movement1, movement2;
    private Rigidbody2D rb;

    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        movement1 = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player == Player.PLAYER_1);
        movement2 = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player == Player.PLAYER_2);
        SetControlledBy(Player.BOTH);
    }

    void Update()
    {
        Vector2 drag = Vector2.zero;
        if ((controlledBy == Player.BOTH || controlledBy == Player.PLAYER_1) && !movement1.isHit)
        {
            drag += dragSpeed * movement1.direction;
        }
        
        if ((controlledBy == Player.BOTH  || controlledBy == Player.PLAYER_2) && !movement2.isHit)
        {
            drag += dragSpeed * movement2.direction;
        }
        Vector2 velocity = rb.velocity + drag;
        rb.velocity = speed * velocity.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (controlledBy != Player.BOTH)
        {
            Target t = collision.transform.GetComponent<Target>();
            if (t != null)
            {
                if (t.player == Player.PLAYER_1)
                    SetControlledBy(Player.PLAYER_2);
                if (t.player == Player.PLAYER_2)
                    SetControlledBy(Player.PLAYER_1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (controlledBy == Player.BOTH)
        {
            Target t = collision.transform.GetComponent<Target>();
            if (t != null)
            {
                if (t.player == Player.PLAYER_1)
                    SetControlledBy(Player.PLAYER_1);
                if (t.player == Player.PLAYER_2)
                    SetControlledBy(Player.PLAYER_2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Target t = collision.transform.GetComponent<Target>();
        if (t != null)
        {
            SetControlledBy(Player.NONE);
        }

        // If Player Hit
        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        if (player != null)
        {
            FindObjectOfType<Field>().SetPoint(player.player);
            player.Hit();
        }
    }

    private void SetControlledBy(Player player)
    {
        controlledBy = player;
        switch (controlledBy)
        {
            case Player.PLAYER_1:
                renderer.material = matPlayer1;
                break;
            case Player.PLAYER_2:
                renderer.material = matPlayer2;
                break;
            case Player.BOTH:
                renderer.material = matBoth;
                break;
            case Player.NONE:
                renderer.material = matNone;
                break;
            default:
                break;
        }
    }
}
