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
        //�� ��ü�� �����ϴ� �ڵ�
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private void SpawnPowerUpWave() {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    //random ������ġ�� ��ȯ�ϴ� �Լ�
    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
