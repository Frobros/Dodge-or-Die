using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController controller;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damping;
    [SerializeField]
    private bool isHit = false;
    [SerializeField]
    private float freezeFor = 1f;

    private float freezeUntil = 0f;
    internal bool IsHit { get { return isHit; } }
    internal float FreezeFor { get { return freezeFor; } }
    internal Vector2 Direction { get { return controller.Direction; } }
    internal PlayerType Type { get { return controller.Type; } }

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isHit)
            rb.velocity = speed * controller.Direction;
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
