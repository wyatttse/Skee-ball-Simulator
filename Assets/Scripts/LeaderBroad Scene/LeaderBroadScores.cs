/*
 * Author: Tse Chi Ho
 * Description: The script is used to display all scores accessed from "LoadSaveSystem" on "gameObject", the UI representing a leaderbroad.
 */

public class LeaderBroadScores : UnityEngine.MonoBehaviour {

    private void Start() {
        var scores = LoadSaveSystem.instance.leaderBroad.scores;
        for (var i = 0; i < scores.Count; ++i) {
            var scoreText = transform.GetChild(i).GetComponent<UnityEngine.UI.Text>();
            scoreText.text = scores[i].ToString();
        }
    }
}
