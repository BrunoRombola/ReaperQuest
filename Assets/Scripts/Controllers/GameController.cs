using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Player Elements
    public int lifeCounter,score,highScore;

    //scene elements
    int i;
    public int fase;
    //GameElements
    public float createTimer, alarm;
    public int quantity;
    [SerializeField] GameObject spawner;
    //GameOverElements
    [SerializeField] Text scoreTitle;
    [SerializeField] Text scoreText;
    [SerializeField] Canvas gameOverScreen;


    void Start()
    {
        gameOverScreen.enabled = false;
        quantity = 0;
        createTimer = 0f;
        alarm = 1f;
        lifeCounter = 3;
        score = 0;
        fase = 1;

    } 
    void Update()
    {
        createTimer += Time.deltaTime;
        if (createTimer > alarm && quantity <10)
        {
            i = IndexCalculator();
            spawner.GetComponent<Spawner>().CreateBall(i);//crea bolas de random
            createTimer = 0;
            quantity++;
        }
        if (lifeCounter == 0)
            GameOver();
    }
    int IndexCalculator()
    {
        if (fase < 3)
            return (Random.Range(0, fase + 1) % 2);//1roja,2verdes//2rojas,2verdes
        else if (fase == 3)
            return ((Random.Range(0, fase + 1) + 1) % 2);//3rojas,2verdes
        else if (fase == 4)
            return ((Random.Range(0, fase) + 1) % 2);//3rojas,2verdes+movimiento
        else if (fase < 8)
            return ((Random.Range(0, fase) + 1) % 3);
        else if (fase < 11)
            return ((Random.Range(0, fase) + 1) % 4);
       else if (fase >= 12)
        {
            if (FindObjectOfType<RedPacman>() == null)
                return ((Random.Range(0, fase) + 1) % 5);
            else
                return ((Random.Range(0, fase) + 1) % 4);
        }
        return 0;
    }

    void GameOver()
    {
        this.gameObject.SetActive(false);
        gameOverScreen.enabled = true;
        scoreText.text = score.ToString();
        scoreTitle.text = "Score";

    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    public void SaveScore(int currentScore) 

    {
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            
        }
    }
}

