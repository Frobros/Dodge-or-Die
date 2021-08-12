using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StageManager : MonoBehaviour
{
    public GameObject winUI;
    Text text;
    public bool isGameDone = false;
    bool isLoading = false;
        

    private void Start()
    {
        Time.timeScale = 1f;
        // MUSIC: Start Theme
        winUI.SetActive(false);
        text = winUI.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!isLoading && isGameDone && Input.anyKeyDown)
        {
            isLoading = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    internal void Win(Player player)
    {
        
        // SFX: Play win sound
        Time.timeScale = 0f;
        winUI.SetActive(true);
        string theWinnerIs = player == Player.PLAYER_1
            ? "RED"
            : "BLUE";
        theWinnerIs += " WINS";
        text.text = theWinnerIs;
        isGameDone = true;

        // Play Particles
        TimeIndependentPlayback particle = FindObjectOfType<TimeIndependentPlayback>();
        GameObject playerObj = Array.Find(FindObjectsOfType<PlayerMovement>(), p => p.player == player).gameObject;
        particle.transform.position = playerObj.transform.position;
        particle.PlayParticles();
        Destroy(playerObj);
    }
}
