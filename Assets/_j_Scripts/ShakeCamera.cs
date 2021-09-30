using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    MenuScript menu;
    private float strength = 1f;
    
    private void Start()
    {
        menu = FindObjectOfType<MenuScript>();
    }
    public void setStrength(float _strength)
    {
        strength = _strength;
        Debug.Log("Shake Strength = " + strength);
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            if ((!menu || !menu.isPaused) && Time.timeScale != 0f)
            {
                float x = originalPos.x + Random.Range(-1f, 1f) * magnitude * strength;
                float y = originalPos.y + Random.Range(-1f, 1f) * magnitude * strength;
                transform.localPosition = new Vector3(x, y, originalPos.z);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
