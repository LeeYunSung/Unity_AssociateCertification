using UnityEngine;

public class RotateCamera : MonoBehaviour{

    [SerializeField] private float rotationSpeed = 5;

    void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
