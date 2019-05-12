public class ConfigurationPanel : UnityEngine.MonoBehaviour {
    public void SetBigHoleScore(string newText) { HoleCollider.scores[0] = int.Parse(newText); }

    public void SetSmallHoleScore(string newText) { HoleCollider.scores[1] = int.Parse(newText); }

    public void SetDuration(string newText) { GameTimer.duration = int.Parse(newText); }

    public void SetMaxTime(string newText) { EnergyBar.maxTime = float.Parse(newText); }
}
