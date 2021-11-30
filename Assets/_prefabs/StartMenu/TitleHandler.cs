using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHandler : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 30;
    }
    public void PlayGame(int _mode)
    {
        FindObjectOfType<GameMode>().OnSelectPlayMode(_mode);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}