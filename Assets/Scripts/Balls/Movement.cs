using System.Collections;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] GameController gameController;
    Rigidbody2D rigidbody;
    [SerializeField]int fase;
    public Vector3 lastVelocity;
    [SerializeField]bool onMove;
    // Start is called before the first frame update
    void Start()
    {
        onMove = false;
        gameController = FindObjectOfType<GameController>();
        fase = gameController.fase;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        this.rigidbody.velocity = new Vector3(0,0,0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameController.fase > 7 && onMove == true)
        {
            rigidbody.AddRelativeForce(new Vector2(Random.Range(-1, 1) * 100, Random.Range(-1, 1) * 100));
            onMove = false;

        }
        else if(gameController.fase > 3 && onMove == false)
        {
            rigidbody.AddRelativeForce(new Vector2(Random.Range(-1, 1) * 100, Random.Range(-1, 1) * 100));
            onMove = true;
        }
        lastVelocity = rigidbody.velocity;
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        var speed = lastVelocity.magnitude;
        rigidbody.velocity = Vector3.Reflect(lastVelocity,collider.contacts[0].normal);

        //rigidbody.velocity = direction * Mathf.Max(speed, 0f);
    }
}
