public class BestScore : UnityEngine.MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        var leaderBroad = LoadSaveSystem.instance.leaderBroad;
        GetComponent<UnityEngine.UI.Text>().text = "Best Score: " + leaderBroad.GetMax();
    }
}
