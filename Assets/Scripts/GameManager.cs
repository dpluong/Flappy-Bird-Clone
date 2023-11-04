using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// GameFlow and logic handler
/// </summary>
public class GameManager : MonoBehaviour
{
    //public static GameManager gameManager;

    [Header("Game Play Settings")]
    public float scrollingSpeed = 3f;
    private bool isGameOver = false;
    private bool isGameStart = false;

    private int currentScore = 0;
    private int scoreToGetMedal = 9;
    private int bestScore;

    const string BESTcurrentScore_KEY = "bestScore";

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance()
    {
        instance = FindObjectOfType<GameManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "Game Manager";
            instance = gameObj.AddComponent<GameManager>();
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BESTcurrentScore_KEY);
    }

    void Update()
    {
        if (isGameOver) 
        {          
            if (Input.GetMouseButtonDown(0)) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        } 
    }

    public void GameOver(bool gameOverFlag) 
    {
        isGameOver = gameOverFlag;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameStart()
    {
        return isGameStart;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("bestScore");
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetMedalScore()
    {
        return scoreToGetMedal;
    }

    public void IncreasePlayerScore() 
    {
        if (!isGameOver) 
        {
            currentScore += 1;
        }
    }
}
