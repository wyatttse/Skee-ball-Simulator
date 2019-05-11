using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    public Score score;

    private void OnTriggerEnter(Collider other) {
        score.AddScore();
    }
}
