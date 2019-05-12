using UnityEngine;

public class LoadSaveSystem : MonoBehaviour
{
    public static LoadSaveSystem instance { get; private set; }
    public SaveDataStorer leaderBroad { get; private set; } = new SaveDataStorer();

    private void Awake() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        var jsonString = PlayerPrefs.GetString("LeaderBroad");
        if (!string.IsNullOrEmpty(jsonString))
            leaderBroad = JsonUtility.FromJson<SaveDataStorer>(jsonString);
    }

    public int Save(int score) {
        var position = leaderBroad.AddScore(score);
        var jsonString = JsonUtility.ToJson(leaderBroad);
        PlayerPrefs.SetString("LeaderBroad", jsonString);

        return position;
    }
}
