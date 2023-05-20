
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 10f;
    private const float X_RANGE = 13f;
    private float horizontalInput;

    [SerializeField] GameObject projectilePrefab;


    void Update(){
        //keep the player in the bounds
        if (transform.position.x > X_RANGE) transform.position = new Vector3(X_RANGE, transform.position.y, transform.position.z);
        else if (transform.position.x < -X_RANGE) transform.position = new Vector3(-X_RANGE, transform.position.y, transform.position.z);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * SPEED * horizontalInput);

        //Lauch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space)) Feed();
    }

    void Feed() {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
