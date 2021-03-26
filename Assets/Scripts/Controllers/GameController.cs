using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Player Elements
    public int lifeCounter;

    //Score Elements
    public ScoreScript score;
    //scene elements
    public GameObject optionMenu;
    //GameOverElements
    [SerializeField] GameObject gameOver;
    //TimerScriptElements
    public TimerScript timer;
    void Awake()
    {
        gameOver = GameObject.Find("GameOverElements");
        lifeCounter = 3;
        score = FindObjectOfType<ScoreScript>();
        //ScoreElementesInitialization
        timer = FindObjectOfType<TimerScript>();
        optionMenu = GameObject.Find("CanvasOptionMenu");
        optionMenu.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        score.scoreModifier();
        //spawner.GetComponent<Spawner>().Spawn();
        if (timer.timer < 0f)
            gameOver.GetComponentInChildren<GameOver>().ActivateGameOver();
        timer.UpdateTimerScreen();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        optionMenu.SetActive(true);
    }



}

