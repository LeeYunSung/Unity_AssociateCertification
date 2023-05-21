using UnityEngine;

public class MoveLeft : MonoBehaviour{

    private const float SPEED = 15f;
    private const float LEFT_BOUND = -10f;

    void Update(){
        if (!PlayerController.Instance.GetGameOver()){
            transform.Translate(Vector3.left * Time.deltaTime * SPEED);
        }
        if (transform.position.x < LEFT_BOUND && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}
