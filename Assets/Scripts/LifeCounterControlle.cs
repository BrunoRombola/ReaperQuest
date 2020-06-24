using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounterControlle : MonoBehaviour
{

    GameController game;
    int counters;
    [SerializeField] Image[] lifeSymbol = new Image [3];
    
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameController>();
        counters = 3;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(game.GetComponent<GameController>().lifeCounter < counters)
        {
            counters--;
            Destroy(lifeSymbol[counters]);
            
        }
    }
}
