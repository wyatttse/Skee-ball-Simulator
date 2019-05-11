using UnityEngine;

public class Ball : MonoBehaviour
{
    private readonly float maxDistance = 20f;
    public bool isThrown { get; private set; }

    public void SetUp(Vector3 position, float energy) {
        gameObject.SetActive(true);
        GetComponent<MeshRenderer>().enabled = true;
        isThrown = true;

        transform.position = position;

        var rigitBody = GetComponent<Rigidbody>();
        rigitBody.mass = Random.Range(3f, 8f);
        rigitBody.velocity = new Vector3(0, energy * Mathf.Sin(Mathf.PI / 6), energy * Mathf.Cos(Mathf.PI / 6));
    }

    // Update is called once per frame
    void Update() {
        var camPosition = Camera.main.transform.position;
        if (Vector3.Distance(camPosition, transform.position) > maxDistance) {
            isThrown = false;
            GetComponent<MeshRenderer>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
