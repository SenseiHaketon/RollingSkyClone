using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float levelSpeed = -5f;
    private float levelSpeedin = -5f;
    public float counter = 5f;
    private int score;
    private int highScore;
    private float slowTimer = 5f;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public Text scoreText;
    public Text highScoreText;
    public Image powerUpImage;
    public Sprite[] powerUps;

    public string activePU;

    public CubeCollider[] otherObjects;

    private GameObject player;

    // Use this for initialization
    void Start () {
        score = 0;
        highScore = 0;
        levelSpeedin = levelSpeed;  
        scoreText.text = score.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
        otherObjects = FindObjectsOfType<CubeCollider>();
        activePU = "null";

        if (PlayerPrefs.HasKey("Score") && SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.DeleteKey("Score");
        }
        else if(PlayerPrefs.HasKey("Score") && SceneManager.GetActiveScene().buildIndex == 2)
        {
            score = PlayerPrefs.GetInt("Score");
        }

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if(highScoreText != null)
          highScoreText.text = highScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        //otherObjects = FindObjectsOfType<CubeCollider>();

        foreach(CubeCollider otherObject in otherObjects)
        {
            if (otherObject != null)
            {
                if (otherObject.transform.position.z <= player.transform.position.z - 10)
                {
                    Destroy(otherObject.gameObject);
                    UpdateOtherObjects();
                }
            }
        }

        scoreText.text = score.ToString();

        if (powerUpImage != null)
        {
            if (activePU == "shield")
            {
                powerUpImage.sprite = powerUps[0];
            }
            else if (activePU == "null")
            {
                powerUpImage.sprite = powerUps[2];
            }
            else if (activePU == "slow")
            {
                levelSpeed = -2.5f;
                slowTimer -= Time.deltaTime;
                powerUpImage.sprite = powerUps[1];
                if (slowTimer <= 0)
                {
                    levelSpeed = levelSpeedin;
                    activePU = "null";
                }
            } 
        }
    }

    public void GameOver()
    {
        if(score > highScore)
            highScore = score;
        SaveScore();
        SceneManager.LoadScene("GameOverMenu");
    }

    public void UpdateOtherObjects()
    {
        otherObjects = null;
        otherObjects = FindObjectsOfType<CubeCollider>();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
