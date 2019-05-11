using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EnergyBar energyBar;
    private Vector3 touchPosition;

    public void OnPointerDown(PointerEventData eventData) {
        touchPosition = eventData.position;
        energyBar.ChargeEnergy();
    }

    public void OnPointerUp(PointerEventData eventData) {
        var energy = energyBar.Release();
    }
}
