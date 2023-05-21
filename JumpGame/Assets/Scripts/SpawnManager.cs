using UnityEngine;

public class SpawnManager : MonoBehaviour{
    [SerializeField] private GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private const float startDelay = 2f;
    private const float repeatRate = 2f;

    void Start(){
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle(){
        if (PlayerController.Instance.GetGameOver()) return;

            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[obstacleIndex],
            spawnPos,
            obstaclePrefabs[obstacleIndex].transform.rotation,
            transform
            );
    }
}