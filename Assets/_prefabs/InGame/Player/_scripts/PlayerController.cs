using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerType type;
    private Vector2 direction = Vector2.zero;

    internal PlayerType Type { get { return type; } }
    internal Vector2 Direction { get { return direction; } }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        FindObjectOfType<MenuHandler>().OnPause(context);
    }
}