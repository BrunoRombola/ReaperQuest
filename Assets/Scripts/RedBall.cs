using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    GameController gameController;
    public float timer, lifelimit;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timer = 0;
        lifelimit = 5f;
    }
    public void BallEffect()
    {

        Destroy(this.gameObject);
        gameController.lifeCounter--;
    }

}
