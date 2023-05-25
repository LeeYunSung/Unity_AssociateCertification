using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;

    void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * forwardInput * speed);
    }
}
