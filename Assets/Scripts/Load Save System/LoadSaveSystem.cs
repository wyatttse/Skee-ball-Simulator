/*
 * Author: Tse Chi Ho
 * Description: The system is used to load and save "leaderbroad" from/to "PlayerPref". "JsonUtility" is used for the serialization.
 */

using UnityEngine;

public class LoadSaveSystem : MonoBehaviour
{
    public static LoadSaveSystem instance { get; private set; }
    public SaveDataStorer leaderBroad { get; private set; } = new SaveDataStorer();

    private void Awake() {
        // As "LoadSaveSystem" is used and "leaderBroad" are accessed through all scenes, singleton pattern is applied
        // to ensure the whole game have only 1 instance and provide a more convenient access.
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        // Load "leaderBroad" from "PlayerPlef" at the start so that different scripts can access it.
        var jsonString = PlayerPrefs.GetString("LeaderBroad");
        if (!string.IsNullOrEmpty(jsonString))
            leaderBroad = JsonUtility.FromJson<SaveDataStorer>(jsonString);
    }


    // Save the just-finished result to "leaderBroad" and "PlayerPlef". The position of "score" in "leaderBroad" is returned.
    public int Save(int score) {
        var position = leaderBroad.AddScore(score);
        var jsonString = JsonUtility.ToJson(leaderBroad);
        PlayerPrefs.SetString("LeaderBroad", jsonString);

        return position;
    }
}
