using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{
    StageManager stageManager;
    public Transform field1;
    public Transform field2;
    public int pointsToWin = 2;
    public int points = 0;
    private bool isChanging;

    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        field1.localPosition = new Vector3(-0.25f, 0f, -0.01f);
        field2.localPosition = new Vector3(0.25f, 0f, -0.01f);

        field1.localScale = new Vector3(0.5f, 1f, 1f);
        field2.localScale = new Vector3(0.5f, 1f, 1f);
    }


    public void SetPoint(PlayerType player)
    {
        StartCoroutine(LerpField(player));
    }

    IEnumerator LerpField(PlayerType player)
    {
        if (!isChanging)
        {
            if (player == PlayerType.PLAYER_2)
            {
                points++;

            }
            else
            {
                points--;
            }
            isChanging = true;
            bool done = false;
            float changeIn = 0.3f;
            float timePassed = 0f;

            float conquerRatio = 0.5f / pointsToWin;
            float conquered = 0.25f * points / pointsToWin;

            Vector3 startPosition1 = field1.localPosition,
                startPosition2 = field2.localPosition;
            Vector3 startScale1 = field1.localScale,
                startScale2 = field2.localScale;

            Vector3 targetPosition1 = new Vector3(-0.25f + conquered, 0f, -0.01f),
                targetPosition2 = new Vector3(0.25f + conquered, 0f, -0.01f);
            Vector3 targetScale1 = startScale1,
                targetScale2 = startScale2;

            if (player == PlayerType.PLAYER_2)
            {
                targetScale1 += new Vector3(conquerRatio, 0f, -0.01f);
                targetScale2 -= new Vector3(conquerRatio, 0f, -0.01f);
            }
            else
            {
                targetScale1 -= new Vector3(conquerRatio, 0f, -0.01f);
                targetScale2 += new Vector3(conquerRatio, 0f, -0.01f);
            }
            while (!done)
            {
                float factor = timePassed / changeIn;
                field1.localPosition = Vector3.Lerp(startPosition1, targetPosition1, factor);
                field2.localPosition = Vector3.Lerp(startPosition2, targetPosition2, factor);

                field1.localScale = Vector3.Lerp(startScale1, targetScale1, factor);
                field2.localScale = Vector3.Lerp(startScale2, targetScale2, factor);
                
                timePassed += Time.deltaTime;
                done = timePassed > changeIn;
                yield return null;
            }
            field1.localPosition = targetPosition1;
            field2.localPosition = targetPosition2;

            field1.localScale = targetScale1;
            field2.localScale = targetScale2;

            isChanging = false;

            if (Mathf.Abs(points) >= pointsToWin)
            {
                stageManager.Win(player);
            }
        }
    }
}
