using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject winUI;
    Text text;
    bool isGameDone = false,
        isLoading = false;

    private void Start()
    {
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
            ? "BLUE"
            : "RED";
        theWinnerIs += " WINS";
        text.text = theWinnerIs;
        isGameDone = true;
    }
}
