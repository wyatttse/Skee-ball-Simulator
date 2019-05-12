using UnityEngine;

public class HoleCollider: MonoBehaviour {
    public static int[] scores = new int[2];
    public GameManager gameManager;
    public string size;

    private void OnTriggerEnter(Collider other) {
        gameManager.AddScore(size == "big" ? scores[0] : scores[1]);
    }
}
