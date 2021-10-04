using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField]
    private float strength = 1f;
    public float Strength { set { strength = value;  } }

    private IndependentDeltaTime time;
    
    private void Start()
    {
        time = FindObjectOfType<IndependentDeltaTime>();
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = originalPos.x + Random.Range(-1f, 1f) * magnitude * strength;
            float y = originalPos.y + Random.Range(-1f, 1f) * magnitude * strength;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
