using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float
        acceleration,
        speed,
        maxSpeed,
        dragSpeed;
    [SerializeField]
    private  PlayerType controlledBy;
    [SerializeField]
    private Material matPlayer1, matPlayer2, matBoth, matNone;
    [SerializeField]
    private Material matTrailPlayer1, matTrailPlayer2;


    private Rigidbody2D rb;
    private Renderer ren;
    private TrailRenderer trail;
    private PlayerMovement movement1, movement2;

    public float Speed { set { speed = value; } }
    public PlayerType ControlledBy { get { return controlledBy; } }

    private void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        ren = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        movement1 = Array.Find(FindObjectsOfType<PlayerMovement>(), player => player.Type == PlayerType.PLAYER_1);
        movement2 = Array.Find(FindObjectsOfType<PlayerMovement>(), player => player.Type == PlayerType.PLAYER_2);
        SetControlledBy(PlayerType.BOTH);
    }

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed = Mathf.Clamp(speed + speed * acceleration * Time.deltaTime, 0f, maxSpeed);
            dragSpeed = dragSpeed + dragSpeed * acceleration * Time.deltaTime;
        }
        Vector2 drag = Vector2.zero;
        if ((controlledBy == PlayerType.BOTH || controlledBy == PlayerType.PLAYER_1) && !movement1.IsHit)
        {
            drag += dragSpeed * Time.deltaTime * movement1.Direction;
        }
        if ((controlledBy == PlayerType.BOTH  || controlledBy == PlayerType.PLAYER_2) && !movement2.IsHit)
        {
            drag += dragSpeed * Time.deltaTime * movement2.Direction;
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

    private void OnTriggerExit2D(Collider2D collider)
    {
        Target t = collider.transform.GetComponent<Target>();
        if (t != null)
        {
            if (t.player == PlayerType.PLAYER_1)
                SetControlledBy(PlayerType.PLAYER_1);
            if (t.player == PlayerType.PLAYER_2)
                SetControlledBy(PlayerType.PLAYER_2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        Target t = collision.transform.GetComponent<Target>();

        // SFX: Hit Last Wall
        if (t != null)
        {
            SetControlledBy(PlayerType.NONE);
            StartCoroutine(FindObjectOfType<ShakeCamera>().Shake(0.1f, 0.2f));
        }
        // SFX: Hit Player
        else if (player != null)
        {
            FindObjectOfType<Field>().SetPoint(player.Type);
            player.Hit(transform.position);
            StartCoroutine(FindObjectOfType<ShakeCamera>().Shake(0.6f, 0.5f * player.FreezeFor));
        }
        // SFX: Hit Anything Else
        else
        {
            StartCoroutine(FindObjectOfType<ShakeCamera>().Shake(0.05f, 0.2f));
        }
    }

    private void SetControlledBy(PlayerType player)
    {
        controlledBy = player;
        switch (controlledBy)
        {
            case PlayerType.PLAYER_1:
                ren.material = matPlayer1;
                trail.material = matTrailPlayer1;
                break;
            case PlayerType.PLAYER_2:
                ren.material = matPlayer2;
                trail.material = matTrailPlayer2;
                break;
            case PlayerType.BOTH:
                ren.material = matBoth;
                break;
            case PlayerType.NONE:
                ren.material = matNone;
                trail.time = 0f;
                break;
            default:
                break;
        }
    }
}
