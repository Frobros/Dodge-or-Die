using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerType type;
    private CharacterController controller;
    private Vector2 direction = Vector2.zero;

    internal PlayerType Type { get { return type; } }
    internal Vector2 Direction { get { return direction; } }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}