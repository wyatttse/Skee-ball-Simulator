using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EnergyBar energyBar;
    public GameObject BallPrefab;
    public Score score;
    public GameObject HighestScore;
    public GameObject LowScore;
    private Vector3 worldPosition;

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

    public void EndGame() {
        var position = LoadSaveSystem.instance.Save(score.score);
        if (position == 0)
            HighestScore.SetActive(true);
        else
            LowScore.SetActive(true);
    }
}
