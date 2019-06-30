using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject LRock;
    public GameObject Player;
    public GameObject Ship;
    public Text ScoreText;
    public Text LivesText;
    public Text WaveText;
    public bool NewGame = true;
    public bool UpdatePoints = false;
    public bool PlayerDead = false;
    public bool UpDateLives = false;
    public int points;
    public int LrocksRemaining = 6;
    public int ShipPoints = 0;
    private int score = 0;
    public int lives = 0;
    private int wave = 0;
    public int ExtraLifeCounter;
    //change later
    int LrocksCount = 6;
    // Start is called before the first frame update
    void Awake()
    {
        
        //singleton pattern allows only 1 gamemanager
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NewGame)
        {
            NewGame = false;
            StartGame();
           
        }
        if(UpdatePoints)
        {
            ScoreText.text = "Score  " + points;
            UpdatePoints = false;
        }
        if(PlayerDead && lives > 0)
        {
            Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
            PlayerDead = false;
            UpDateLives = true;

            
        }
        if(UpDateLives)
        {
            LivesText.text = "Lives  " + lives;
            UpDateLives = false;
        }
        // keep the player busy by adding more rocks to shoot
        if (LrocksRemaining < 1)
        {
            SpawnLargeRock();
            wave += 1;
            WaveText.text = "Wave  " + wave;
        }
        if(ShipPoints > 500)
        {
            Instantiate(Ship, new Vector3(9.0f, 4.2f, 0), Quaternion.identity);
            ShipPoints = 0;
        }
        if(ExtraLifeCounter > 10000)
        {
            lives += 1;
            LivesText.text = "Lives  " + lives;
            ExtraLifeCounter = 0;
        }
        if(PlayerDead && lives < 1)
        {
            
            SceneManager.LoadScene("GameOver");
        }
        
        
    }
    void StartGame()
    {
        UpdatePoints = false;
        PlayerDead = false;
        UpDateLives = false;
        ShipPoints = 0;
        ExtraLifeCounter = 0;
        lives = 3;
        wave = 1;
        score = 0;
        points = 0;
        LrocksCount = 6;
        ScoreText.text = "Score  " + score;
        LivesText.text = "Lives  " + lives;
        WaveText.text = "Wave  " + wave;
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
        SpawnLargeRock();
    }
    
    
    void SpawnLargeRock()
    {
        

        for(int i= 0; i < LrocksCount; i++)
        {
            Instantiate(LRock,
                new Vector3(Random.Range(-9.0f, 9.0f),
                    Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
        LrocksRemaining = 6;
    }

    
}
