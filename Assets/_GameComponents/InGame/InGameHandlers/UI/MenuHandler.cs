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
            if (isPaused) OnResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void OnResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SetWinMenuActive(PlayerType player)
    {
        string resultText = "";
        Color buttonColor;

        isGameOver = true;
        winMenu.SetActive(true);
        winText.gameObject.SetActive(true);
        
        if (player == PlayerType.PLAYER_1)
        {
            resultText = "RED";
            winImage.color = new Color(1f, 73f / 255f, 119f / 255f);
            buttonColor = new Color(205f / 255f, 0f , 44f / 255f);
        }
        else
        {
            resultText = "BLUE";
            winImage.color = new Color(0f, 204f / 255f, 1f);
            buttonColor = new Color(0f, 60f / 255f, 178f / 255f);
        }

        foreach (Button button in winMenu.GetComponentsInChildren<Button>())
        {
            ColorBlock colors = button.colors;
            colors.highlightedColor = buttonColor;
            colors.selectedColor = buttonColor;
            button.colors = colors;
        }

        winText.text = resultText + " WINS";
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
