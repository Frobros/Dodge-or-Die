using UnityEngine;

public class IndependentDeltaTime : MonoBehaviour
{
    public float time = 0;
    public float deltaTime = 0;

    void Update()
    {
        deltaTime = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
    }
}
