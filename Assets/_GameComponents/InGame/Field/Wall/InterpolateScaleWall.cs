using System.Collections;
using UnityEngine;

public enum EaseType
{
    LINEAR,
    QUADRIC,
    ELASTIC
}

public class InterpolateScaleWall : MonoBehaviour
{
    [SerializeField]
    PlayerType player;
    [SerializeField]
    private EaseType easeType;
    [SerializeField]
    private float scaleBy;
    [SerializeField]
    private float tScaleFor;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public IEnumerator Scale()
    {
        float t = 0f;
        Vector3 targetScale = scaleBy * originalScale;

        while (t < tScaleFor)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, Ease(t / tScaleFor));
            t += Time.deltaTime;
            yield return null;
        }

        t = tScaleFor;
        while (t > 0f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, Ease(t / tScaleFor));
            t -= Time.deltaTime;
            yield return null;
        }
    }


    public float Ease(float t)
    {
        switch(easeType)
        {
            case EaseType.QUADRIC:
                return EaseQuadric(t);
            case EaseType.ELASTIC:
                return EaseElastic(t);
            default:
                return t;
        }
    }

    private float EaseQuadric(float t)
    {
        return t * t;
    }

    private float EaseElastic(float t)
    {
        if (t == 0) return 0;
        if (t == 1) return 1;
        return -Mathf.Pow(2f, 10f * (t -= 1f)) * Mathf.Sin((t - 0.1f) * (2f * Mathf.PI) / 0.4f);
    }
}
