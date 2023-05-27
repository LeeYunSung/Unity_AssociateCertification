using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour{ 

    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorgue = 10;
    private float xRange = 4;
    private float ySpawnPos = -3;

    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    void Start() {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RangeForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorgue(), RandomTorgue(), RandomTorgue(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private Vector3 RangeForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorgue() {
        return Random.Range(-maxTorgue, maxTorgue);
    }

    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    //마우스 이벤트
    private void OnMouseDown() {
        Destroy(gameObject);
        GameManager.gameManger.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    //트리거 이벤트
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
