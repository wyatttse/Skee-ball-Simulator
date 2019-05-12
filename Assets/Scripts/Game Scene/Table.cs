using UnityEngine;

public class Table : MonoBehaviour
{
    public static int difficulty;
    private readonly int maxDistance = 3;
    private bool isLeft;

    // Update is called once per frame
    private void Update() {
        var position = transform.position;
        var distance = Time.deltaTime * difficulty;

        if (isLeft)
            transform.position = new Vector3(position.x - distance, position.y, position.z);
        else
            transform.position = new Vector3(position.x + distance, position.y, position.z);

        if (position.x >= maxDistance)
            isLeft = true;
        else if (position.x <= -maxDistance)
            isLeft = false;
    }
}
