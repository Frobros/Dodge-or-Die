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
        bool isRunning = movement.direction.magnitude > 0 && !movement.isHit;
        anim.SetBool("IsRunning", isRunning);
        if (isRunning)
        {
            transform.rotation = Quaternion.LookRotation((Vector3)movement.direction, -Vector3.forward);
        }
    }

    internal void Hit()
    {
        anim.SetTrigger("IsHit");
    }
}
