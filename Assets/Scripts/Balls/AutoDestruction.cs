using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] double timer;
    double lifeLimit;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timer = 0;
        lifeLimit = 10;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeLimit)
        {
            Destroy(this.gameObject);
            gameController.quantity--;

        }
    }
}
