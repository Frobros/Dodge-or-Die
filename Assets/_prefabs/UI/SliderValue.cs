using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField]
    private SliderValueType valueOfInterest;
    private Slider slider;
    private GameMode mode;

    void Start()
    {
        mode = FindObjectOfType<GameMode>();
        slider = GetComponent<Slider>();
        slider.value = mode.getValueOfInterest(valueOfInterest);
    }

    public void OnChangeValue(float value)
    {
        mode.OnChangeValue(valueOfInterest, value);
    }

    public void OnValueChanged()
    {
        mode.OnValueChanged(valueOfInterest);
    }
}
