using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameManager gameManager;

    public void CountTime() {
        StartCoroutine(CountTimeCoroutine());

        System.Collections.IEnumerator CountTimeCoroutine() {
            var gameTimerText = GetComponent<UnityEngine.UI.Text>();

            for (var i = 30; i > 0; --i) {
                yield return new WaitForSeconds(1f);
                gameTimerText.text = "Time Left: " + i;
            }

            gameManager.EndGame();
        }
    }
}
