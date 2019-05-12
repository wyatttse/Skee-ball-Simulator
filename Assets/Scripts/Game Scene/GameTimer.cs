/*
 * Author: Tse Chi Ho
 * Description: The script is used to count the time left to play the game.
 */

using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameManager gameManager;
    public static int duration = 30; // static property allow setting the duration in a cross-scenes manner

    public void CountTime() {
        StartCoroutine(CountTimeCoroutine());

        System.Collections.IEnumerator CountTimeCoroutine() {
            var gameTimerText = GetComponent<UnityEngine.UI.Text>();

            for (var i = duration; i > 0; --i) {
                yield return new WaitForSeconds(1f);
                gameTimerText.text = "Time Left: " + i;
            }

            // End the game when the time is up
            gameManager.EndGame();
        }
    }
}
