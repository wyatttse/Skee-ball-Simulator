using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EnergyBar energyBar;
    public GameObject BallPrefab;
    public Transform PopUp;
    private Vector3 worldPosition;
    private int score;

    public void OnPointerDown(PointerEventData eventData) {
        if (Ball.isThrown)
            return;

        var cam = Camera.main;
        Vector3 touchPosition = eventData.position;
        touchPosition.z = cam.nearClipPlane + 1;
        worldPosition = cam.ScreenToWorldPoint(touchPosition);

        energyBar.ChargeEnergy();
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (Ball.isThrown)
            return;

        var energy = energyBar.Release();
        var ball = Instantiate(BallPrefab).GetComponent<Ball>();
        ball.SetUp(worldPosition, energy);
    }

    public void AddScore(int score) {
        this.score += Random.Range(1, 10) + score;
    }

    public void EndGame() {
        PopUp.gameObject.SetActive(true);

        var scoreText = PopUp.Find("Score").GetComponent<Text>();
        scoreText.text += score.ToString();

        var position = LoadSaveSystem.instance.Save(score);
        var positionText = PopUp.Find("Position").GetComponent<Text>();
        switch (position) {
            case 0:
                positionText.text += "1st";
                break;
            case 1:
                positionText.text += "2nd";
                break;
            case 2:
                positionText.text += "3rd";
                break;
            case 3:
                positionText.text += "4th";
                break;
            case 4:
                positionText.text += "5th";
                break;
            case 5:
                positionText.text += "None";
                break;
        }

        if (position == 0) {
            var HighestScore = PopUp.Find("Highest Score");
            HighestScore.gameObject.SetActive(true);
        }
        else {
            var LowScore = PopUp.Find("Low Score");
            LowScore.gameObject.SetActive(true);
        }

    }
}
