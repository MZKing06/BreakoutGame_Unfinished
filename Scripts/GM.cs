using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{
    public static GM instance = null;
    //private bool gameOver;

    public int lives;
    public int bricks = 21;
    public float resetDelay = 1f;
    public GameObject barrier;
    public GameObject paddle;
    public GameObject gameOverText;
    public GameObject deathParticles;
    public GameObject bricksPrefab;
    public Text youWinText;

    public Text highscoreText;
    public GameObject[] livesArray;

    public TextMeshProUGUI textMeshLives;
    public TextMeshProUGUI textMeshScore;

    public int score;
    GameObject clonePaddle;

    public int _currentlevel;

    public GameObject _SaveCanvas;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //assign the UI Canvas to the _savecanvas variable
        _SaveCanvas = GameObject.FindGameObjectWithTag("UI_Canvas");

        SetUpPaddle();

        highscoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        bricksPrefab.SetActive(true);
        //highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        //gameOver = false;

        //This gets gets the score per scene on awake
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Lives"))
        {
            score = PlayerPrefs.GetInt("Score", score);
            lives = PlayerPrefs.GetInt("Lives", lives);
        }

        if (_currentlevel == 1)
        {
            lives = 6;
            bricks = 7;
            score = 0;
        }

        AssigningUI();



    }

    public void SetUp()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;

        //Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void AssigningUI()
    {
        livesArray[0] = GameObject.Find("Image");
        livesArray[1] = GameObject.Find("Image1");
        livesArray[2] = GameObject.Find("Image2");
        livesArray[3] = GameObject.Find("Image3");
        livesArray[4] = GameObject.Find("Image4");
        livesArray[5] = GameObject.Find("Image5");
        livesArray[6] = GameObject.Find("Image6");
        livesArray[7] = GameObject.Find("Image7");
        livesArray[8] = GameObject.Find("Image8");
        livesArray[9] = GameObject.Find("Image9");


    }
    
    public void LoseLife()
    {

        lives--;
        score = score - 20;
        textMeshLives.text = "Lives: " + lives;
        textMeshScore.text = "Score: " + score.ToString();
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        livesArray[lives].SetActive(false);
        //Destroy(startPaddle);
        Destroy(clonePaddle);
        Invoke("SetUpPaddle", resetDelay);
        GameIsOver();


    }

    void SetUpPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;

    }

    //This is the function that sets the score per scene
    public void Save()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Lives", lives);

    }




    public void Level2()
    {
        if (bricks < 1 && _currentlevel == 1)
        {        
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scene2");
            GM.instance.Save();
            bricks = 14;
            DontDestroyOnLoad(_SaveCanvas.gameObject);
            _currentlevel = 2;
            bricksPrefab = GameObject.FindGameObjectWithTag("StackofBricks");

        }

    }

    public void Level3()
    {
        if (bricks < 1 && _currentlevel == 2)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scene3");
            GM.instance.Save();
            bricks = 14;
            DontDestroyOnLoad(_SaveCanvas.gameObject);
            _currentlevel = 3;
            bricksPrefab = GameObject.FindGameObjectWithTag("StackofBricks");

        }

    }

    public void Level4()
    {
        if (bricks < 1 && _currentlevel == 3)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scene4");
            GM.instance.Save();
            bricks = 21;
            DontDestroyOnLoad(_SaveCanvas.gameObject);
            _currentlevel = 4;
            bricksPrefab = GameObject.FindGameObjectWithTag("StackofBricks");

        }

    }

    public void Level5()
    {
        if (bricks < 1 && _currentlevel == 4)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scene5");
            GM.instance.Save();
            bricks = 21;
            DontDestroyOnLoad(_SaveCanvas.gameObject);
            _currentlevel = 5;
            bricksPrefab = GameObject.FindGameObjectWithTag("StackofBricks");

        }

    }

    public void GameIsOver()
    {
        


        if (lives < 1)
        {
            //gameOver = true;
            gameOverText.SetActive(true);
            highscoreText.gameObject.SetActive(true);


            //Reset Function called here
            Invoke("Reset", resetDelay);

            //Reset the Score and lives when u lose
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Lives", 6);
            livesArray[lives].SetActive(true);

        }

    }

    //function to Reset the scene when u lose the game. 
    void Reset()
    {
        Time.timeScale = 1f;
        //U win go back to main menu
        SceneManager.LoadScene("Menu");
    }


    void Retry()
    {
        Time.timeScale = 1f;
        //U lose retry game again
        SceneManager.LoadScene("Scene1");

    }

    void HacksBro()
    {
        
            youWinText.gameObject.SetActive(true);

            Time.timeScale = 0.25f;
            Invoke("Level2", 0.50f);
        
    }


    public void DestroyBrick()
    {
        bricks--;
        GameIsOver();
        //call the score when a brick is destroyed
        SetScoreText();

        //Level 2-5 functions called in DestroyBrick
        if (bricks < 1 && _currentlevel == 1)
        {
            // youWinText.gameObject.SetActive(true);

            Time.timeScale = 0.25f;
            Invoke("Level2", 0.50f);
        }
        else if (bricks < 1 && _currentlevel == 2)
        {
            Time.timeScale = 0.25f;
            Invoke("Level3", 0.50f);
        }
        else if (bricks < 1 && _currentlevel == 3)
        {
            Time.timeScale = 0.25f;
            Invoke("Level4", 0.50f);
        }
        else if (bricks < 1 && _currentlevel == 4)
        {
            Time.timeScale = 0.25f;
            Invoke("Level5", 0.50f);
        }
        else if (bricks < 1 && _currentlevel == 5)
        {
            Time.timeScale = 0.25f;
            youWinText.gameObject.SetActive(true);
            Invoke("Reset", 0.50f);
        }
    }

    void SetScoreText()
    {
        //score = current score total + 10
        score = score + 10;
        //update the score text
        textMeshScore.text = "Score: " + score.ToString();
        //Unity Player Prefs for high score
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = "HighScore: " + score.ToString();

        }

    }




    //public void ResetHighScore()
    //{
    //    if (Input.GetKeyDown(KeyCode.Delete))
    //    {
    //        //delete key deletes highscore
    //        PlayerPrefs.DeleteKey("HighScore");

    //        //bricks = 0;
    //        //HacksBro();
    //    }

    //}

    //void Update()
    //{
    //    ResetHighScore();
    //}
    



}
