using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isThrown { get; private set; }

    private readonly float maxDistance = 20f;
    private readonly float maxTime = 5f;
    private float timePassed;

    public void SetUp(Vector3 position, float energy) {
        gameObject.SetActive(true);
        GetComponent<MeshRenderer>().enabled = true;
        isThrown = true;

        transform.position = position;

        var rigitBody = GetComponent<Rigidbody>();
        rigitBody.mass = Random.Range(3f, 8f);
        rigitBody.velocity = new Vector3(0, energy * Mathf.Sin(Mathf.PI / 6), energy * Mathf.Cos(Mathf.PI / 6));
    }

    private void FixedUpdate() {
        timePassed += Time.fixedDeltaTime;

        var camPosition = Camera.main.transform.position;
        if (Vector3.Distance(camPosition, transform.position) > maxDistance || timePassed >= maxTime) {
            timePassed = 0f;
            isThrown = false;
            GetComponent<MeshRenderer>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
