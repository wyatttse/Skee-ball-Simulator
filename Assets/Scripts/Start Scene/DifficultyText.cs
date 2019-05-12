/*
 * Author: Tse Chi Ho
 * Description: The script is used to alter the difficulty set on "Configuration Panel "to the game. As the display of difficulty is also needed to change,
 *              the function is seperated from "ConfigurationPanel" for a better efficiency and readability
 */

public class DifficultyText : UnityEngine.MonoBehaviour {
    public void SetDifficulty(float newValue) {
        var difficulty = (int)newValue;
        GetComponent<UnityEngine.UI.Text>().text = difficulty.ToString();
        Table.difficulty = difficulty;
    }
}
