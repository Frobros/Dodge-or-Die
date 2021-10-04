using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class SetupSpawners : MonoBehaviour
{
    [SerializeField]
    private SpawnPlayer spawnPlayer1, spawnPlayer2;
    [SerializeField]
    private GameObject player1, player2, enemyAI;

    public void AssignAndSpawnPlayers(PlayerMode mode)
    {
        spawnPlayer1.Player = player1;
        if (mode == PlayerMode.TWO_PLAYER)
        {
            spawnPlayer2.Player = player2;
        } 
        else
        {
            spawnPlayer2.Player = enemyAI;
        }
        GameObject currentPlayer1 = spawnPlayer1.Spawn();
        GameObject currentPlayer2 = spawnPlayer2.Spawn();
        RepairInputDevice(currentPlayer1, currentPlayer2, mode);
    }


    /*
     * The new Input System does currently not allow two players on one device.
     * Therefore this work-around is necessary.
     * https://forum.unity.com/threads/2-players-on-same-input-device.763949/
     */
    private void RepairInputDevice(GameObject currentPlayer1, GameObject currentPlayer2, PlayerMode mode)
    {
        PlayerInput input1 = currentPlayer1.GetComponent<PlayerInput>();
        input1.user.UnpairDevices();
        InputUser.PerformPairingWithDevice(Keyboard.current, input1.user);
        input1.user.ActivateControlScheme("KeyboardLeft");
        if (mode == PlayerMode.TWO_PLAYER)
        {
            PlayerInput input2 = currentPlayer2.GetComponent<PlayerInput>();
            // Discard existing assignments.
            input2.user.UnpairDevices();
            InputUser.PerformPairingWithDevice(Keyboard.current, input2.user);
            input2.user.ActivateControlScheme("KeyboardRight");
        }
    }
}
