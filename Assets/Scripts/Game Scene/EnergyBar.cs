using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    private readonly float maxEnergy = 20f;
    private readonly float maxTime = 1f;
    private Coroutine oldCoroutine;
    private float energy;

    public void ChargeEnergy() {
        oldCoroutine = StartCoroutine(ChargeEnergyCoroutine());

        System.Collections.IEnumerator ChargeEnergyCoroutine() {
            var isMax = false;
            var totalTime = 0f;

            while (true) {
                var deltaTime = Time.deltaTime;

                if (!isMax) {
                    if (totalTime + deltaTime > maxTime) {
                        deltaTime = maxTime - totalTime;
                        isMax = true;
                    }

                    totalTime += deltaTime;
                }
                else {
                    if (totalTime - deltaTime < 0) {
                        deltaTime = totalTime;
                        isMax = false;
                    }

                    totalTime -= deltaTime;
                }

                energy = maxEnergy * totalTime / maxTime;

                var rectTransform = GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(energy * 10, rectTransform.sizeDelta.y);

                yield return new WaitForSeconds(deltaTime);
            }
        }
    }

    public float Release() {
        StopCoroutine(oldCoroutine);

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0, rectTransform.sizeDelta.y);

        var tmp = energy;
        energy = 0;

        return tmp;
    }


}
