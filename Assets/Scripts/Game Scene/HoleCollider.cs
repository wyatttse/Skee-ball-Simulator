/*
 * Author: Tse Chi Ho
 * Description: The script is a trigger when a ball is shot in a hole
 */

using UnityEngine;

public class HoleCollider: MonoBehaviour {
    // static property allow setting the score for 2 holes in a cross-scenes manner.
    // scores[0] is for the big hole whereas scores[1] is for the small hole.
    public static int[] scores = { 10, 30 };
    public GameManager gameManager;
    public string size;

    private void OnTriggerEnter(Collider other) {
        gameManager.AddScore(size == "big" ? scores[0] : scores[1]);
    }
}
