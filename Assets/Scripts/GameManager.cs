using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// GameFlow and logic handler
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Game Play Settings")]
    public float scrollingSpeed = 0f;

    [Header("UI Manager")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject medal;
    [SerializeField] private GameObject finalScore;
    [SerializeField] private GameObject bestScoreText;

    private bool isGameOver = false;
    private int currentScore = 0;
    private int scoreToGetMedal = 9;
    private int bestScore;

    const string BESTcurrentScore_KEY = "bestScore";

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BESTcurrentScore_KEY);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) 
        {
            UpdateScorePanel();
            gameOverPanel.SetActive(true);
            
            if (Input.GetMouseButtonDown(0)) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if (Input.GetMouseButtonDown(0)) 
        {
            scrollingSpeed = 3f;
            startMenu.GetComponent<Animator>().SetTrigger("close");
        } 
    }

    public void IsGameOver(bool gameOverFlag) 
    {
        isGameOver = gameOverFlag;
    }

    public void PlayerScored() 
    {
        if (!isGameOver) 
        {
            currentScore += 1;
            scoreText.GetComponent<Text>().text = currentScore.ToString();
        }
    }

    public void UpdateScorePanel() 
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        
        if (currentScore > bestScore) 
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        
        bestScoreText.GetComponent<Text>().text = bestScore.ToString();
        finalScore.GetComponent<Text>().text = currentScore.ToString();
        
        if (currentScore >= scoreToGetMedal) 
        {
            medal.SetActive(true);
        }
    }
}
