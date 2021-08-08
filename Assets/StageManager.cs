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
