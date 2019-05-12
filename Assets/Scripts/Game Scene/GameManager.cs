/*
 * Author: Tse Chi Ho
 * Description: The script is the manager of the game which act as a bridge to handle interactions between each scripts and GameObject instances,
 *              thus forming the logic of whole game.
 */
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager: MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public EnergyBar energyBar;
    public GameObject BallPrefab;
    public Transform PopUp;
    public SceneFade sceneFade;
    private Vector3 worldPosition;
    private int score;

    // Change the energy when the player touch the monitor.
    // The first-touched position is recorded and adjusted for the inistantiation of ball
    public void OnPointerDown(PointerEventData eventData) {
        if (Ball.isThrown)
            return;

        var cam = Camera.main;
        Vector3 touchPosition = eventData.position;
        touchPosition.z = cam.nearClipPlane + 1;
        worldPosition = cam.ScreenToWorldPoint(touchPosition);

        energyBar.ChargeEnergy();
    }

    // Get the energy and inistantiate a ball
    public void OnPointerUp(PointerEventData eventData) {
        if (Ball.isThrown)
            return;

        var energy = energyBar.Release();
        var ball = Instantiate(BallPrefab).GetComponent<Ball>();
        ball.SetUp(worldPosition, energy);
    }

    // Add the score with bonus marks from different balls
    // The bonus is calculated in this function instead of stored in each ball in order to save the memory
    public void AddScore(int score) {
        this.score += Random.Range(1, 10) + score;
    }

    // Show the pop up panel when the game is ended.
    public void EndGame() {
        PopUp.gameObject.SetActive(true);

        // Display the score on the panel
        var scoreText = PopUp.Find("Score").GetComponent<Text>();
        scoreText.text += score.ToString();

        // Display the position on the panel
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

        // Show the message according to whether the performance is the best
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
