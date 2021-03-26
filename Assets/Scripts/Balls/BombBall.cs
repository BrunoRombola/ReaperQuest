using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBall : MonoBehaviour
{
    GameController gameController;
    public double time = 1;
    [SerializeField]double lifeLimit;
    public bool isAwake = false,isExploded =false;
    // Start is called before the first frame update
    void Start()
    {

        gameController = FindObjectOfType<GameController>();
        lifeLimit = 5;
        this.gameObject.GetComponentInChildren<Text>().text = lifeLimit.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAwake)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                lifeLimit--;
                time = 1;
            }
            this.gameObject.GetComponentInChildren<Text>().text = lifeLimit.ToString();
        }
        if (lifeLimit <= 0)
            Explotion();
        DamageToPlayer();

    }
    public void Explotion()
    {
        isExploded = true;
        Destroy(this.gameObject);
    }
    void DamageToPlayer() 
    {
        float radius = 10;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var collider in colliders) 
        {
            if (collider.tag == "Player" && isExploded && !collider.GetComponent<PlayerControllerPC>().shieldOn) 
            {
                gameController.score.score -= 2;
            }
        }
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
            isAwake = true;
    }
    void Animation()
    {

    }
}
