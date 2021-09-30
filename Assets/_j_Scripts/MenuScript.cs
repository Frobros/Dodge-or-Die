using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject overlay;
    public GameObject button1vs1;
    public GameObject buttonSolo;
    public GameObject buttonExit;
    public GameObject buttonResume;
    public GameObject buttonRestart;
    public GameObject buttonQuit;
    public Text textWin;
    public bool isPaused, isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //overlay.SetActive(false);
        buttonResume.SetActive(false);
        buttonQuit.SetActive(false);
        buttonRestart.SetActive(false);
        textWin.gameObject.SetActive(false);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                OnResume();
            }
            else
            {
                OnPause();
            }
        }
    }

    public void OnPause()
    {
        if (!isGameOver)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }


    public void OnResume()
    {
        if (!isGameOver)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
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

    public void OnRestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnQuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnPlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitApplication()
    {
        Application.Quit();
    }
}
