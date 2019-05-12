/*
 * Author: Tse Chi Ho
 * Description: The script is for the projectile movement of each ball
 */
using UnityEngine;

public class Ball : MonoBehaviour
{
    // When "isThrown" is true, not any other ball can be instantiated.
    // static property let "gameManager" do not need to know the exact ball throwing which changes frequently
    public static bool isThrown { get; private set; }

    private readonly float maxDistance = 20f;
    private readonly float maxTime = 5f;
    private float timePassed;

    // Initialize the ball according to the first touching position and the energy when the finger release.
    public void SetUp(Vector3 position, float energy) {
        isThrown = true;

        // set the position of the ball
        transform.position = position;

        var rigitBody = GetComponent<Rigidbody>();
        rigitBody.mass = Random.Range(5f, 10f); // Randomly assign a mass to the balls
        rigitBody.velocity = new Vector3(0, energy * Mathf.Sin(Mathf.PI / 6), energy * Mathf.Cos(Mathf.PI / 6)); // set the velocity vector calculated by "energy"
    }

    private void Update() {
        // Calculate the time passed.
        timePassed += Time.deltaTime;

        // Check whether 5 seconds are passed or the ball has certain distance from camera
        var camPosition = Camera.main.transform.position;
        if (Vector3.Distance(camPosition, transform.position) > maxDistance || timePassed >= maxTime) {
            isThrown = false;
            Destroy(gameObject);
        }
    }
}
