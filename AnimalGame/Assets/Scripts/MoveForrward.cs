using UnityEngine;

public class MoveForrward : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private const float Z_RANGE = 25;

    private void Update() {
        if (transform.position.z > Z_RANGE) {
            Destroy(gameObject);
        }
        else if (transform.position.z < -Z_RANGE) {
            Destroy(gameObject);
            GameManager.Instance.StopGame();
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
