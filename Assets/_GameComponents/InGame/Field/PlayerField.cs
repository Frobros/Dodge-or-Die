using UnityEngine;

public class PlayerField : MonoBehaviour
{
    [SerializeField]
    private PlayerType player;
    public PlayerType Player { get { return player; } }
}
