using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public int highScore;
    private GameObject FirstPage;
    private GameObject GameOverMenu;
    private GameObject MainMenu;
    private GameObject SettingPannel;

    ObstaclesGenerator obstaclesGenerator;
    FlyBird flyBird;
    public TextMeshProUGUI scoreText, highScoreText, finalScore;
    bool val = false;

    private void Awake()
    {
        PauseGame();
        scoreText.text = "SCORE: " + score.ToString("F0");
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HIGHSCORE", 0).ToString("F0");

        obstaclesGenerator = FindObjectOfType<ObstaclesGenerator>();
        flyBird = FindObjectOfType<FlyBird>();
        SettingPannel = GameObject.Find("UI").transform.Find("SettingPanel").gameObject;
        MainMenu = GameObject.Find("UI").transform.Find("MainMenu").gameObject;
        FirstPage = GameObject.Find("UI").transform.Find("FirstPage").gameObject;
        GameOverMenu = GameObject.Find("UI").transform.Find("GameOver").gameObject;

        GameOverMenu.SetActive(false);    
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("PopName") == 1)
        { 
            FirstPage.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
    private void Update()
    {
        CountScore();
    }
    public void DestroyFirstPage()
    {
        Destroy(FirstPage);
        ResumeGame();
        val = true;
        PlayerPrefs.SetInt("PopName", val ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void CountScore()
    {
        scoreText.text = "SCORE: " + score;
        finalScore.text = "SCORE: " + score;
        if (score > PlayerPrefs.GetInt("HIGHSCORE"))
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            PlayerPrefs.Save();
            highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HIGHSCORE");
        }
    }

    public void GameOverFnc()
    {
        GameOverMenu.SetActive(true);         
        PauseGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {      
        MainMenu.SetActive(false);
        SettingPannel.SetActive(true);
        score = 0;
    }

    public void OnRestart()
    {
        flyBird.transform.position = flyBird.initialPosition;
        ObjectPooler.instance.DeletePooledObject();
        score = 0;
        ResumeGame();
        GameOverMenu.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Game");
    }

    public void onEasySelect()
    {
        SettingPannel.SetActive(false);
        ResumeGame();
        obstaclesGenerator.waitTime = 2;
        obstaclesGenerator.minHeight = -4;
        obstaclesGenerator.maxHeight = 4;
    }
    public void onMediumSelect()
    {
        SettingPannel.SetActive(false);
        ResumeGame();
        obstaclesGenerator.waitTime = 1.5f;
        obstaclesGenerator.minHeight = -6;
        obstaclesGenerator.maxHeight = 6;
    }

    public void onHardSelect()
    {
        SettingPannel.SetActive(false);
        ResumeGame();
        obstaclesGenerator.waitTime = 1f;
        obstaclesGenerator.minHeight = -6;
        obstaclesGenerator.maxHeight = 7;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
    }

}
