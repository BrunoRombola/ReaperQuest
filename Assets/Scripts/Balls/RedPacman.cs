using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPacman : MonoBehaviour
{
    GameController gameController;
    [SerializeField] GameObject objectToDestroy;
    AutoDestruction script;
    private void Start()
    {
        script.enabled = false;
        gameController = FindObjectOfType<GameController>();
    }
    
    private void Update()
    {

        if (GameObject.FindGameObjectWithTag("GreenBall"))
        { 
            DetectGameObject();
            this.transform.position = Vector3.MoveTowards(this.transform.position, objectToDestroy.transform.position, 0.25f );
        
        }

        if (this.transform.position == objectToDestroy.transform.position)
        {
            Destroy(objectToDestroy);
            gameController.GetComponent<GameController>().quantity--;
        }
    }

    public void BallEffect()
    {
        Destroy(this.gameObject);
        gameController.quantity--;
    }
    void DetectGameObject()
    {
        objectToDestroy = GameObject.FindGameObjectWithTag("GreenBall");
    }

}
