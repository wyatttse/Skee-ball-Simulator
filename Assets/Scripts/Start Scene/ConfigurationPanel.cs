/*
 * Author: Tse Chi Ho
 * Description: The class is a collection of functions to set different configuration on "Configuration Panel" to the game.
 */

public class ConfigurationPanel : UnityEngine.MonoBehaviour {
    // Set the score when a ball shoots into the big hole
    public void SetBigHoleScore(string newText) { HoleCollider.scores[0] = int.Parse(newText); }

    // Set the score when a ball shoots into the small hole
    public void SetSmallHoleScore(string newText) { HoleCollider.scores[1] = int.Parse(newText); }

    // Set the duration of the game
    public void SetDuration(string newText) { GameTimer.duration = int.Parse(newText); }

    // Set the time needed for the energy bar to reach the maximum
    public void SetMaxTime(string newText) { EnergyBar.maxTime = float.Parse(newText); }
}
