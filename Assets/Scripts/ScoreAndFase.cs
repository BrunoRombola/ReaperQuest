using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreAndFase : MonoBehaviour
{
    public GameController game;
    public Text score;
    public Text fase;
    int limit;
    
    // Start is called before the first frame update
    void Start () 
    { 
        score.fontSize = 40;
        score.text = game.score.ToString();
        fase.fontSize = 40;
        fase.text =game.fase.ToString();
        limit = 10;
    }

    // Update is called once per frame
    void Update()
    { 
        score.text = game.score.ToString();
        if (game.score >= limit)
        {
            game.fase++;
            limit *= 2;
            fase.text = (game.fase).ToString();
        }   
    }
}
