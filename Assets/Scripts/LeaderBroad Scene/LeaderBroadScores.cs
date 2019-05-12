public class LeaderBroadScores : UnityEngine.MonoBehaviour {
    // Start is called before the first frame update
    private void Start()
    {
        var scores = LoadSaveSystem.instance.leaderBroad.scores;
        for (var i = 0; i< scores.Count; ++i) {
            var scoreText = transform.GetChild(i).GetComponent<UnityEngine.UI.Text>();
            scoreText.text = scores[i].ToString();
        }
    }
}
