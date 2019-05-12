using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    public GameManager gameManager;
    public int score;

    private void OnTriggerEnter(Collider other) {
        gameManager.AddScore(score);
    }
}
