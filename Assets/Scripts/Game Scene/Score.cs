using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    public void AddScore() {
        score += 10;
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }
}
