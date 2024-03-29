﻿using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public static float maxTime = 1f;
    private readonly float maxEnergy = 20f;
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
                    if (totalTime + deltaTime > maxTime)
                        isMax = true;

                    totalTime += deltaTime;
                }
                else {
                    if (totalTime - deltaTime < 0) 
                        isMax = false;

                    totalTime -= deltaTime;
                }

                //energy = maxEnergy * totalTime / maxTime;

                var a = -maxEnergy / Mathf.Pow(-maxTime, 2);
                energy = a * Mathf.Pow(totalTime - maxTime, 2) + maxEnergy;

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
