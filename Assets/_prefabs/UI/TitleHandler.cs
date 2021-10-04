using UnityEngine;
using UnityEngine.SceneManagement;
using DarkTonic.MasterAudio;

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
        // The Custom Events can be triggered here, but it does not work with the AudioObject changing the volumes. Nothing happens.
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}