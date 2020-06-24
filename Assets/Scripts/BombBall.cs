using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class BombBall : MonoBehaviour
{
    public int timeLimit;
    public GameController game;
    public double time = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 5; 
        game = FindObjectOfType<GameController>();
        this.gameObject.GetComponentInChildren<Text>().text = timeLimit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            timeLimit--;
            time = 1.00;
        }
        this.gameObject.GetComponentInChildren<Text>().text = timeLimit.ToString();
        if(timeLimit == 0)
        {
            BallEffect();
        }
    }
    public void BallEffect()
    {
        Destroy(this.gameObject);
        game.GetComponent<GameController>().lifeCounter--;
        game.quantity--;
    }
    public void OnClick()
    {
        Destroy(this.gameObject);
        game.quantity--;
    }


}
