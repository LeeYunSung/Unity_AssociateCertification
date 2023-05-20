
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    private const float START_DELAY = 2f;
    private const float SPAWN_INTERVAL = 1.5f;

    private void Start() {
        InvokeRepeating("SpawnAnimal", START_DELAY, SPAWN_INTERVAL);
    }
    private void SpawnAnimal() {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int randomX = Random.Range(-13, 13);

        Instantiate(animalPrefabs[animalIndex],
            new Vector3(randomX, 0, 20),
            animalPrefabs[animalIndex].transform.rotation,
            gameObject.transform);
    }
}
