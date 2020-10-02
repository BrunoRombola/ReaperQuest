using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBall : MonoBehaviour
{
    AutoDestruction script;
    GameController game;

    void Start()
    {
        script = this.gameObject.GetComponent<AutoDestruction>();
        script.enabled = false;
        game = FindObjectOfType<GameController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "GreenBall")
        {
            collision.gameObject.SendMessage("BallEffect");
            Destroy(collision.gameObject);
            game.quantity--;
        }

    }

    public void BallEffect()
    {
        Destroy(this.gameObject);
        game.quantity--;
    }

}
