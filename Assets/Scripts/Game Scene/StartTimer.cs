using UnityEngine;

public class StartTimer: MonoBehaviour {
    public GameTimer gameTimer;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(CountTimeCoroutine());
        gameTimer.CountTime();
        gameObject.SetActive(false);

        System.Collections.IEnumerator CountTimeCoroutine() {
            var startCounter = GetComponent<UnityEngine.UI.Text>();
            for (var i = 3; i > 0; --i) {
                startCounter.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
