using UnityEngine;

public class ExitListener : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
