using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerUpIndicator;

    private bool hasPowerUp = false;
    private float powerupStrength = 15.0f;

    void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        transform.GetComponent<Rigidbody>().AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Destroy(other.gameObject);
            //powerUpContdownRoutine �ڷ�ƾ ����
            StartCoroutine(powerUpContdownRoutine());
        }
    }

    IEnumerator powerUpContdownRoutine(){
        powerUpIndicator.SetActive(true);

        //7�ʰ� ��ٷȴٰ� �Ʒ� ���� ����
        yield return new WaitForSeconds(7);

        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp){
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
