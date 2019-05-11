using UnityEngine;

public class StartTimer: MonoBehaviour {
    private void Start() {
        StartCoroutine(CountTimeCoroutine());

        System.Collections.IEnumerator CountTimeCoroutine() {
            var startCounter = GetComponent<UnityEngine.UI.Text>();
            for (var i = 3; i > 0; --i) {
                startCounter.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            gameObject.SetActive(false);
        }
    }
}
