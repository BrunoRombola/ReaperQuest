using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VioletBall : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void BallEffect()
    {
        Destroy(this.gameObject);
        gameController.score.score += 5;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            BallEffect();
    }

}
