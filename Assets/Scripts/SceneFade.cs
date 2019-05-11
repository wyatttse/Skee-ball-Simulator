using UnityEngine;

public class SceneFade: MonoBehaviour {
    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine());

        System.Collections.IEnumerator LoadSceneCoroutine() {
            GetComponent<Animator>().Play("Fade Out");
            yield return new WaitForSeconds(1f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
