/*
 * Author: Tse Chi Ho
 * Description: The class is used to display the best score stored in "leaderBroad" of "LoadSaveSystem"
 */

public class BestScore : UnityEngine.MonoBehaviour {
    private void Start() {
        var leaderBroad = LoadSaveSystem.instance.leaderBroad;
        GetComponent<UnityEngine.UI.Text>().text += leaderBroad.GetMax();
    }
}
