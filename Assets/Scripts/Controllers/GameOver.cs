using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject game;
    Canvas gameOverScreen;

    [SerializeField]Text scoreText;
    [SerializeField]Text scoreTitle;

    void Start()
    {
        game = GameObject.Find("GameController");
        gameOverScreen = this.gameObject.GetComponentInChildren<Canvas>();
        gameOverScreen.enabled = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenue ()
    {
        SceneManager.LoadScene("MenuInicio");

    }
    public void ActivateGameOver()
    {
        gameOverScreen.enabled = true;
        scoreText.text = game.GetComponent<GameController>().score.score.ToString();
        scoreTitle.text = "Score";
        game.SetActive(false);
    }
}
