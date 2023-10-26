using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Manager")]
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject medal;
    [SerializeField]
    private GameObject finalScore;
    [SerializeField]
    private GameObject bestScoreText;

    public void UpdateScorePanel()
    {
        int bestScore = GameManager.Instance.GetBestScore();
        int currentScore = GameManager.Instance.GetCurrentScore();
        int scoreToGetMedal = GameManager.Instance.GetMedalScore();        

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

        gameOverPanel.SetActive(true);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            UpdateScorePanel();
        }
        else
        {
            scoreText.GetComponent<Text>().text = GameManager.Instance.GetCurrentScore().ToString();
        }

        if ((Input.GetMouseButtonDown(0)))
        {
            startMenu.GetComponent<Animator>().SetTrigger("close");
        }
    }
}
