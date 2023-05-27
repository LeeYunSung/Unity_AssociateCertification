using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverWindow;
    private float spawnRate = 1.0f;
    private int gameScore = 0;

    public static GameManager gameManger;

    void Awake() {
        if (gameManger == null) gameManger = this;
    }

    void Start() {
        Time.timeScale = 1;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        gameScore += scoreToAdd;
        scoreText.text = "Score: "+ gameScore.ToString();

        if (gameScore < 0){
            gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
