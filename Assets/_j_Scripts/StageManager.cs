using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StageManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
        // MUSIC: Start Theme
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    internal void Win(Player player)
    {
        // SFX: Play win sound
        Time.timeScale = 0f;
        FindObjectOfType<MenuScript>().SetWinMenuActive(true, player);

        // Play Particles
        ParticlePlayback particle = FindObjectOfType<ParticlePlayback>();
        GameObject playerObj = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player == player).gameObject;
        particle.transform.position = playerObj.transform.position;
        particle.PlayParticles();
        Destroy(playerObj);
    }
}
