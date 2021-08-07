using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 direction1 = Vector2.zero;
    public Vector2 direction2 = Vector2.zero;
    void Update()
    {
        MoveDirectionPlayer1();
        MoveDirectionPlayer2();

    }

    private void MoveDirectionPlayer1()
    {
        direction1 = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction1 += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction1 += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction1 += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction1 += Vector2.right;
        }
        direction1 = direction1.magnitude > 0.5f ? Vector2.ClampMagnitude(direction1, 1f) : Vector2.zero;
        PlayerMovement player = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player ==Player.PLAYER_1);
        player.direction = direction1;
    }

    private void MoveDirectionPlayer2()
    {
        direction2 = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction2 += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction2 += Vector2.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction2 += Vector2.down;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction2 += Vector2.right;
        }
        direction2 = direction2.magnitude > 0.5f ? Vector2.ClampMagnitude(direction2, 1f) : Vector2.zero;
        PlayerMovement player = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player == Player.PLAYER_2);
        player.direction = direction2;
    }
}
