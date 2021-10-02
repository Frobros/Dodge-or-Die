using System;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    PlayerMovement movement;
    Animator anim;

    void Start()
    {
        movement = GetComponentInParent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool isRunning = movement.Direction.magnitude > 0 && !movement.IsHit;
        anim.SetBool("IsRunning", isRunning);
        if (isRunning)
        {
            LookAt(movement.Direction);
        }
    }

    internal void Hit(Vector3 hitDirection)
    {
        LookAt(hitDirection);
        anim.SetTrigger("IsHit");
    }

    public void LookAt(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction, -Vector3.forward);
    }
}
