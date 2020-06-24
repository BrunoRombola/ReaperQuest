using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    public GameController gameController;
    public float timer, lifelimit;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timer = 0;
        lifelimit = 7f;
    }
    public void BallEffect()
    {
        Destroy(this.gameObject);
        gameController.GetComponent<GameController>().score+= 2;
        gameController.GetComponent<GameController>().quantity--;

    }
}
