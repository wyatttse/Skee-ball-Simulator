using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public SceneFade sceneFade;

    // Update is called once per frame
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape)) {
            sceneFade.LoadScene("Start Scene");
        }
    }
}
