using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
        // MUSIC: Start Theme
    }

    internal void Win(PlayerType player)
    {
        // SFX: Play win sound
        Time.timeScale = 0f;
        FindObjectOfType<MenuHandler>().SetWinMenuActive(true, player);

        // Play Particles
        ParticlePlayback particle = FindObjectOfType<ParticlePlayback>();
        GameObject playerObj = Array.Find(FindObjectsOfType<PlayerController>(), p => p.Type == player).gameObject;
        particle.transform.position = playerObj.transform.position;
        particle.PlayParticles();
        Destroy(playerObj);
    }

    void OnReset(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
