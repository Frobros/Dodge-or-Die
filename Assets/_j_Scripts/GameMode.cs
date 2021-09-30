using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayMode
{
    TWO_PLAYER,
    SOLO
}

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private PlayMode mode;

    [SerializeField] 
    private int ballSpeed = 10;

    [SerializeField] 
    private int sfxVolume = 100;

    [SerializeField] 
    private int musicVolume = 100;
    
    [SerializeField] 
    private int screenShake = 100;

    private static GameMode _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
        }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            // TODO: When AI is merged, set aiMovement.controlledByAI = true;
            FindObjectOfType<ShakeCamera>().setStrength(screenShake);
            FindObjectOfType<Ball>().speed = ballSpeed;
        }
    }
    public void OnSelectPlayMode(int _mode)
    {
        mode = (PlayMode) _mode;
    }

    private void OnChangeBallSpeed(System.Single _ballSpeed)
    {
        ballSpeed = (int) _ballSpeed;
    }

    private void OnChangeSfxVolume(System.Single _sfxVolume)
    {
        sfxVolume = (int)_sfxVolume;
    }
    private void OnChangeMusicVolume(System.Single _musicVolume)
    {
        musicVolume = (int)_musicVolume;
        // TODO: Set Music Volume here
    }

    private void OnChangeScreenShakeIntensity(System.Single _screenShake)
    {
        screenShake = (int) _screenShake;
    }

    private void OnReleaseSfxVolume()
    {
        // TODO: Play SFX (e.g. applause) with sfxVolume here 
    }

    private void OnReleaseScreenShakeIntensity()
    {
        // TODO: Trigger ScreenShake with screenShake here
    }


    internal int getValueOfInterest(SliderValueType valueOfInterest)
    {
        switch (valueOfInterest)
        {
            case SliderValueType.BALL_SPEED:
                return ballSpeed;
            case SliderValueType.SCREEN_SHAKE_INTENSITY:
                return screenShake;
            case SliderValueType.SFX_VOLUME:
                return sfxVolume;
            case SliderValueType.MUSIC_VOLUME:
                return musicVolume;
            default:
                Debug.LogWarning("You tried to choose a not-existing value for your slider!");
                return 0;
        }
    }

    internal void OnValueChanged(SliderValueType valueOfInterest)
    {
        switch (valueOfInterest)
        {
            case SliderValueType.BALL_SPEED:
                break;
            case SliderValueType.SCREEN_SHAKE_INTENSITY:
                break;
            case SliderValueType.SFX_VOLUME:
                break;
            case SliderValueType.MUSIC_VOLUME:
                break;
            default:
                Debug.LogWarning("You tried to choose a not-existing value for your slider!");
                break;
        }
    }

    internal void OnChangeValue(SliderValueType valueOfInterest, float value)
    {
        switch (valueOfInterest)
        {
            case SliderValueType.BALL_SPEED:
                OnChangeBallSpeed(value);
                break;
            case SliderValueType.SCREEN_SHAKE_INTENSITY:
                OnChangeScreenShakeIntensity(value);
                break;
            case SliderValueType.SFX_VOLUME:
                OnChangeSfxVolume(value);
                break;
            case SliderValueType.MUSIC_VOLUME:
                OnChangeMusicVolume(value);
                break;
            default:
                Debug.LogWarning("You tried to choose a not-existing value for your slider!");
                break;
        }
    }

}
