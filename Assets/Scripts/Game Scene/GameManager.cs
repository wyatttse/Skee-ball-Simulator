using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EnergyBar energyBar;
    public Ball ball;
    private Vector3 worldPosition;

    public void OnPointerDown(PointerEventData eventData) {
        if (ball.isThrown)
            return;

        var cam = Camera.main;
        Vector3 touchPosition = eventData.position;
        touchPosition.z = cam.nearClipPlane + 2;
        worldPosition = cam.ScreenToWorldPoint(touchPosition);

        energyBar.ChargeEnergy();
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (ball.isThrown)
            return;

        var energy = energyBar.Release();
        ball.SetUp(worldPosition, energy);
    }
}
