using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public GameController gameController;
    public Text scoreText;
    public int score;
    
    // Start is called before the first frame update
    void Start () 
    {
        score = 0;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    public void scoreModifier()
    {
        scoreText.text = Mathf.Max(score,0).ToString();
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
