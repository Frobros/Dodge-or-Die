using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BoxCollider2D coll;
    Rigidbody2D rb;

    public Player player;
    public Vector2 speed;
    public Vector3 scale;

    internal Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rb.velocity = speed * direction;
        transform.localScale = scale;
    }
}
