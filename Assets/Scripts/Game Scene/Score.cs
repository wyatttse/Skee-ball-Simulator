using UnityEngine;

public class Score : MonoBehaviour
{
    public int score { get; private set; }

    public void AddScore() {
        score += 10;
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }
}
