using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public GameObject Player { set { player = value; } }

    public GameObject Spawn()
    {
        return Instantiate<GameObject>(player, transform.position, Quaternion.identity, null);
    }
}
