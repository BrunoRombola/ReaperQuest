using System.Collections;
using UnityEditor;
using UnityEngine;

public class BallBasics : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] double timer;
    public double lifeLimit;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timer = 0;
        lifeLimit = 7;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeLimit)
        {
            Destroy(this.gameObject);
        }
    }
    public void BallEffect() 
    { 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            this.gameObject.GetComponent<Rigidbody2D>().Sleep();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
    }
}
