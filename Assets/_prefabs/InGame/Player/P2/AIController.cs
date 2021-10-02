using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private bool isControlledByAI;
    [SerializeField]
    private float requiredBallDistance = 5f;
    [SerializeField]
    private float threshold;
    [SerializeField]
    private float tolerance;
    [SerializeField]
    private LayerMask whatIsWall;
    private PlayerInput input;
    private PlayerController controller;
    private Ball ball;
    private Transform otherPlayer;

    private Vector2 direction = Vector2.zero;

    public Vector2 Direction { get { return direction; } }
    void Start()
    {
        input = GetComponent<PlayerInput>();
        controller = GetComponent<PlayerController>();
        if (isControlledByAI)
        {
            Destroy(input);
            Destroy(controller);
        }
        else Destroy(this);

        GetComponent<PlayerMovement>().SetControlledByAI();
        ball = FindObjectOfType<Ball>();
        otherPlayer = System.Array.Find(FindObjectsOfType<PlayerController>(), p => p.Type == PlayerType.PLAYER_1).transform;
    }

    void Update()
    {
        if (ball.ControlledBy == PlayerType.PLAYER_1 || ball.ControlledBy == PlayerType.NONE)
        {
            Vector2 ballDirection = transform.position - ball.transform.position;
            if (ballDirection.magnitude < requiredBallDistance)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, requiredBallDistance, whatIsWall);
                Debug.DrawLine(transform.position, transform.position + (Vector3)direction);
                if (raycastHit.collider)
                {
                    Vector2 fleeDirection = requiredBallDistance * ballDirection.normalized;

                    for (int i = 1; i < 180; i++)
                    {
                        Vector2 dirA = RotateVectorByDegrees(fleeDirection, i);
                        RaycastHit2D hitA = Physics2D.Raycast(transform.position, dirA, requiredBallDistance, whatIsWall);
                        if (hitA.collider)
                        {
                            dirA = hitA.point - (Vector2)transform.position;
                        }
                        if (threshold < dirA.magnitude)
                        {
                            direction = dirA;
                            Debug.DrawLine(transform.position, transform.position + (Vector3)dirA, Color.red);
                            break;
                        }
                        else
                        {
                            Debug.DrawLine(transform.position, transform.position + (Vector3)dirA, Color.blue);
                        }


                        Vector2 dirB = RotateVectorByDegrees(fleeDirection, -i);
                        RaycastHit2D hitB = Physics2D.Raycast(transform.position, dirB, requiredBallDistance, whatIsWall);
                        if (hitB.collider)
                        {
                            dirB = hitB.point - (Vector2)transform.position;
                        }
                        if (threshold < dirB.magnitude)
                        {
                            direction = dirB;
                            Debug.DrawLine(transform.position, transform.position + (Vector3)dirB, Color.red);
                            break;
                        }
                        else
                        {
                            Debug.DrawLine(transform.position, transform.position + (Vector3)dirB, Color.green);
                        }
                    }
                }
                else
                {
                    direction = new Vector2(-ballDirection.y, ballDirection.x);
                }
            }
            else
            {
                // direction = ballDirection;
                direction = Vector2.zero;
            }
            direction.Normalize();
        }


        else if (ball.ControlledBy == PlayerType.PLAYER_2)
        {
            direction = otherPlayer.position - ball.transform.position;
            direction.Normalize();
            Debug.DrawLine(ball.transform.position, ball.transform.position + (Vector3)direction);
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private bool InTolerance(float threshold, float value, float tolerance)
    {
        return threshold - tolerance <= value && value <= threshold + tolerance;
    }

    float DistanceLineTwoPoint(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
    {
        return Mathf.Abs((point.x - lineStart.x) * (-lineEnd.y + lineStart.y) + (point.y - lineStart.y) * (lineEnd.x - lineStart.x))
            / Mathf.Sqrt(Mathf.Pow(-lineEnd.y + lineStart.y, 2f) + Mathf.Pow(lineEnd.x - lineStart.x, 2f));
    }

    Vector2 RotateVectorByDegrees(Vector2 v, float deg)
    {
        float rad = Mathf.Deg2Rad * deg;
        float sinRad = Mathf.Sin(rad);
        float cosRad = Mathf.Cos(rad);
        return new Vector2(
            v.x * cosRad - v.y * sinRad,
            v.x * sinRad + v.y * cosRad
        );
    }
}
