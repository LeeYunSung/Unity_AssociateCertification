
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPopup;

    public static GameManager Instance;
    private void Awake() {
        if (Instance == null) Instance = this;
    }

    public void StartGame() {
        Time.timeScale = 1f;
        gameOverPopup.SetActive(false);
    }

    public void StopGame() {
        Time.timeScale = 0f;
        gameOverPopup.SetActive(true);
    }
}
