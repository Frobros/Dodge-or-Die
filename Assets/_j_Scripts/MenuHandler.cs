using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject winMenu;
    [SerializeField]
    private TextMeshProUGUI winText;
    [SerializeField]
    private Image winImage;

    public bool isPaused, isGameOver;

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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SetWinMenuActive(bool active, PlayerType player)
    {
        winMenu.SetActive(active);
        winText.gameObject.SetActive(active);
        string resultText = "";
        if (player == PlayerType.PLAYER_1)
        {
            resultText = "RED WINS";
            winImage.color = new Color(1f, 73f/255f, 119f/255f);
        }
        else
        {
            resultText = "BLUE WINS";
            winImage.color = new Color(0f, 170f / 255f, 1f);
        }
        winText.text = resultText;
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

    public void OnQuitApplication()
    {
        Application.Quit();
    }
}
