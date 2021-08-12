using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        overlay.SetActive(false);
        buttonResume.SetActive(false);
        buttonQuit.SetActive(false);
        buttonRestart.SetActive(false);
        textWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (!isGameOver)
        {
            SetPauseMenuActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }


    public void ResumeGame()
    {
        if (!isGameOver)
        {
            SetPauseMenuActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    private void SetPauseMenuActive(bool active)
    {
        textWin.gameObject.SetActive(false);
        overlay.SetActive(active);
        buttonResume.SetActive(active);
        buttonQuit.SetActive(active);
        buttonRestart.SetActive(active);
    }

    public void SetWinMenuActive(bool active, Player player)
    {
        overlay.SetActive(false);
        buttonResume.SetActive(false);
        buttonQuit.SetActive(active);
        buttonRestart.SetActive(active);
        textWin.gameObject.SetActive(active);
        string theWinnerIs = player == Player.PLAYER_1
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
