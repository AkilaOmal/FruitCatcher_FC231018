using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;

    [Header("Game Settings")]
    public int lives = 3;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverPanel is not assigned!");
        }

        UpdateUI();
    }
     

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateUI();

        Debug.Log("Score updated: " + score);
    }

    public void LoseLife()
    {
        if (isGameOver) return;

        lives--;

        if (lives < 0)
            lives = 0;

        UpdateUI();

        Debug.Log("Lives remaining: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("Score Text is not assigned in Inspector!");
        }

        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            Debug.LogError("Lives Text is not assigned in Inspector!");
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over! Final score: " + score);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
