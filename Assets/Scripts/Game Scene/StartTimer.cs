/*
 * Author: Tse Chi Ho
 * Description: The script is used to count 3 seconds when the game begins.
 */

using UnityEngine;

public class StartTimer: MonoBehaviour {
    public GameTimer gameTimer;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(CountTimeCoroutine());

        System.Collections.IEnumerator CountTimeCoroutine() {
            var startCounter = GetComponent<UnityEngine.UI.Text>();
            for (var i = 3; i > 0; --i) {
                startCounter.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            // Start to count down the time for the game
            gameTimer.CountTime();
            gameObject.SetActive(false);
        }
    }
}
