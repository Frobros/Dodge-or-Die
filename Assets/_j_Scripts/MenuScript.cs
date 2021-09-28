using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject overlay;
    public GameObject buttonResume;
    public GameObject buttonRestart;
    public GameObject buttonQuit;
    public Text textWin;
    public bool isPaused, isGameOver;

    void Start()
    {
        overlay.SetActive(false);
        buttonResume.SetActive(false);
        buttonQuit.SetActive(false);
        buttonRestart.SetActive(false);
        textWin.gameObject.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!isGameOver)
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        SetPauseMenuActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        SetPauseMenuActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void SetPauseMenuActive(bool active)
    {
        textWin.gameObject.SetActive(false);
        overlay.SetActive(active);
        buttonResume.SetActive(active);
        buttonQuit.SetActive(active);
        buttonRestart.SetActive(active);
    }

    public void SetWinMenuActive(bool active, PlayerType player)
    {
        overlay.SetActive(false);
        buttonResume.SetActive(false);
        buttonQuit.SetActive(active);
        buttonRestart.SetActive(active);
        textWin.gameObject.SetActive(active);
        string theWinnerIs = player == PlayerType.PLAYER_1
            ? "RED"
            : "BLUE";
        theWinnerIs += " WINS";
        textWin.text = theWinnerIs;
        isGameOver = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("title");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
