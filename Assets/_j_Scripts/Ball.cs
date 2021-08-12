using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed,
        dragSpeed;
    public Player controlledBy;
    public Material matPlayer1, matPlayer2, matBoth, matNone;
    public Material matTrailPlayer1, matTrailPlayer2;
    private PlayerMovement movement1, movement2;
    private Rigidbody2D rb;
    private Renderer ren;

    private TrailRenderer trail;

    private void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        ren = GetComponent<Renderer>();
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
            drag += dragSpeed * Time.deltaTime * movement1.direction;
        }
        if ((controlledBy == Player.BOTH  || controlledBy == Player.PLAYER_2) && !movement2.isHit)
        {
            drag += dragSpeed * Time.deltaTime * movement2.direction;
        }

        if (drag.magnitude > 0)
        {
            trail.time = Mathf.Clamp(trail.time + 0.01f, 0f, 0.5f);
        }
        else
        {
            trail.time = Mathf.Clamp(trail.time - 0.01f, 0f, 0.5f);
        }

        Vector2 velocity = rb.velocity + drag;
        rb.velocity = speed * velocity.normalized;
    }

    private void OnTriggerExit2D(Collider2D collision)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        Target t = collision.transform.GetComponent<Target>();

        // SFX: Hit Last Wall
        if (t != null)
        {
            SetControlledBy(Player.NONE);
            StartCoroutine(FindObjectOfType<ShakeCamera>().Shake(0.1f, 0.2f));
        }
        // SFX: Hit Player
        else if (player != null)
        {
            FindObjectOfType<Field>().SetPoint(player.player);
            player.Hit(transform.position);
        }
        // SFX: Hit Anything Else
        else
        {
            StartCoroutine(FindObjectOfType<ShakeCamera>().Shake(0.1f, 0.2f));
        }
    }

    private void SetControlledBy(Player player)
    {
        controlledBy = player;
        switch (controlledBy)
        {
            case Player.PLAYER_1:
                ren.material = matPlayer1;
                trail.material = matTrailPlayer1;
                break;
            case Player.PLAYER_2:
                ren.material = matPlayer2;
                trail.material = matTrailPlayer2;
                break;
            case Player.BOTH:
                ren.material = matBoth;
                break;
            case Player.NONE:
                ren.material = matNone;
                break;
            default:
                break;
        }
    }
}
