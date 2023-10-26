using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    // Making this class a singleton that destroys all other instances when a instance is created
    // there are also other methods to implement singleton pattern
    // default methods are private so you can remove private
    void Awake()
    {
        int gameSessionsCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionsCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
