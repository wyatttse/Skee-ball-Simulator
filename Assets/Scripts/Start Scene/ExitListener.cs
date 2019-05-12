/*
 * Author: Tse Chi Ho
 * Description: The script is used to listen whether the player of Andriod press Back button to exit the game
 */

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
