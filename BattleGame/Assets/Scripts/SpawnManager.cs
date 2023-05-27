using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;

    private float spawnRange = 9;
    private int enemyCount;
    private int waveNumber = 1;

    void Start() {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUpWave();
    }

    void Update() {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUpWave();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        //적 객체를 복제하는 코드
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private void SpawnPowerUpWave() {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    //random 생성위치를 반환하는 함수
    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
