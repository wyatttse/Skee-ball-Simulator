public class DifficultyText : UnityEngine.MonoBehaviour {
    public void SetDifficulty(float newValue) {
        var difficulty = (int)newValue;
        GetComponent<UnityEngine.UI.Text>().text = difficulty.ToString();
        Table.difficulty = difficulty;
    }
}
