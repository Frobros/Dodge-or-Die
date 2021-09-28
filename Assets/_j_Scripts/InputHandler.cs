using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerInput player1;
    [SerializeField]
    private PlayerInput player2;
    
    /*
     * The new Input System does currently not allow two players on one device.
     * Therefore this work-around is necessary.
     * https://forum.unity.com/threads/2-players-on-same-input-device.763949/
     */
    private void Awake()
    {

        // Discard existing assignments.
        player1.user.UnpairDevices();
        player2.user.UnpairDevices();
        InputUser.PerformPairingWithDevice(Keyboard.current, user: player1.user);
        InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);

        player1.user.ActivateControlScheme("KeyboardLeft");
        player2.user.ActivateControlScheme("KeyboardRight");
    }
}
