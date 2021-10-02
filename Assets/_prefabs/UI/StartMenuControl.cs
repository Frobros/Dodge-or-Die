using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenuControl : MonoBehaviour
{
    public GameObject titleFirstButton,
        mainFirstButton,
        playFirstButton,
        controlsFirstButton,
        settingsFirstButton;



    public void SetSelectedGameObject(int i)
    {
        EventSystem.current.SetSelectedGameObject(null);
        switch (i)
        {
            case 0:
                EventSystem.current.SetSelectedGameObject(titleFirstButton);
                break;
            case 1:
                EventSystem.current.SetSelectedGameObject(mainFirstButton);
                break;
            case 2:
                EventSystem.current.SetSelectedGameObject(playFirstButton);
                break;
            case 3:
                EventSystem.current.SetSelectedGameObject(controlsFirstButton);
                break;
            case 4:
                EventSystem.current.SetSelectedGameObject(settingsFirstButton);
                break;
            default:
                break;
        }
    }
}
