using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{
    public Transform field1;
    public Transform field2;
    public int pointsToWin = 2;
    public int points = 0;

    private void Start()
    {
        field1.localPosition = new Vector3(-0.25f, 0f, -0.01f);
        field2.localPosition = new Vector3(0.25f, 0f, -0.01f);

        field1.localScale = new Vector3(0.5f, 1f, 1f);
        field2.localScale = new Vector3(0.5f, 1f, 1f);
    }


    public void SetPoint(Player player)
    {
        if (player == Player.PLAYER_2)
        {
            points++;
            float conquerRatio = 0.5f / pointsToWin;
            float conquered = 0.25f * points / pointsToWin;

            field1.localPosition = new Vector3(-0.25f + conquered, 0f, -0.01f);
            field2.localPosition = new Vector3(0.25f + conquered, 0f, -0.01f);

            field1.localScale += new Vector3(conquerRatio, 0f, 0f);
            field2.localScale -= new Vector3(conquerRatio, 0f, 0f);
        }
        else
        {
            points--;
            float conquered = 0.25f * points / pointsToWin;
            float conquerRatio = 0.5f / pointsToWin;

            field1.localPosition = new Vector3(-0.25f + conquered, 0f, -0.01f);
            field2.localPosition = new Vector3(0.25f + conquered, 0f, -0.01f);

            field1.localScale -= new Vector3(conquerRatio, 0f, 0f);
            field2.localScale += new Vector3(conquerRatio, 0f, 0f);
        }

        if (Mathf.Abs(points) >= pointsToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
