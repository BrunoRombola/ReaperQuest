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
        gameController.score.score+= 2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            BallEffect();
    }
}
