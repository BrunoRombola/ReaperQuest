using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    GameObject game;
    [SerializeField]Text timerTitle;
    [SerializeField]Text timerCounter;

    public float timer;
    public float time;
    void Start()
    {
        game = GameObject.Find("GameController");
        timer = 120f;
        time = 1f;
    }

    public void UpdateTimerScreen()
    {
        timerCounter.text = timeModification();
    }
    string timeModification()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            timer--;
            time = 1f;
        }
        int minutes = (int)(timer / 60);
        int seconds = (int)(timer % 60);
        string text = seconds > 9 ?minutes.ToString() + ':' + seconds.ToString(): minutes.ToString() + ":0" + seconds.ToString();
        return text;
    }
}