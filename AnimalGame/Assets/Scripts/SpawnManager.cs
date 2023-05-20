
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            int randomX = Random.Range(-13, 13);

            Instantiate(animalPrefabs[animalIndex], new Vector3(randomX, 0, 20), animalPrefabs[animalIndex].transform.rotation);
        } 
    }
}
