using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// GameFlow and logic handler
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Input, config")]
    [SerializeField] public float speed = 0f;

    [Header("Scene refs")]
    // Start is called before the first frame update
    public GameObject startMenu;
    public GameObject gameOverPanel;
    public GameObject scoreText;
    public GameObject medal;
    public GameObject finalScore;
    public GameObject bestScoreText;

    bool _isGameOver = false;
    private int _score = 0;
    private int _scoreToGetMedal = 9;
    private int bestScore;
    

    #region SIngleton
    public static GameManager gameManager;
    void Awake()
    {
        // singleton.
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion//Singleton


    const string BEST_SCORE_KEY = "bestScore";
    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver) {
            UpdateScorePanel();
            gameOverPanel.SetActive(true);
            
            if (Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if (Input.GetMouseButtonDown(0)) {
            speed = 3f;
            startMenu.GetComponent<Animator>().SetTrigger("close");
        } 
    }

    public void DisplayGameOverPanel() {
        _isGameOver = true;
    }

    public void PlayerScored() 
    {
        if (!_isGameOver) {
            _score += 1;
            scoreText.GetComponent<Text>().text = _score.ToString();
        }
    }

    public void UpdateScorePanel() {
        bestScore = PlayerPrefs.GetInt("bestScore");
        
        if (_score > bestScore) {
            bestScore = _score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        bestScoreText.GetComponent<Text>().text = bestScore.ToString();
        finalScore.GetComponent<Text>().text = _score.ToString();
        if (_score >= _scoreToGetMedal) {
            medal.SetActive(true);
        }
    }
}
