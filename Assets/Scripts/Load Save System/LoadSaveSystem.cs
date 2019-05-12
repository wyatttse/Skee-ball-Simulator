using UnityEngine;

public class LoadSaveSystem : MonoBehaviour
{
    public static LoadSaveSystem instance { get; private set; }
    private SaveDataStorer leaderBroad = new SaveDataStorer();

    private void Awake() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public int Save(int score) {
        var position = leaderBroad.AddScore(score);
        var jsonString = JsonUtility.ToJson(leaderBroad);
        PlayerPrefs.SetString("LeaderBroad", jsonString);

        return position;
    }
}
