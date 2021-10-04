using UnityEngine;
using System;
using DarkTonic.MasterAudio;

public class StageManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    internal void Win(PlayerType playerType)
    {
        // SFX: Play win sound
        Time.timeScale = 0f;
        FindObjectOfType<MenuHandler>().SetWinMenuActive(playerType);

        // Play Particles
        ParticlePlayback particle = FindObjectOfType<ParticlePlayback>();
        GameObject player = Array.Find(FindObjectsOfType<PlayerController>(), p => p.Type == playerType).gameObject;
        particle.transform.position = player.transform.position;
        particle.PlayParticles();
        Destroy(player);
    }
}
