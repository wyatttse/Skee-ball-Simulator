using UnityEngine;

public class SceneFade: MonoBehaviour {

    private void Start() {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine());

        System.Collections.IEnumerator LoadSceneCoroutine() {
            GetComponent<Animator>().Play("Fade Out");
            yield return new WaitForSeconds(1f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
