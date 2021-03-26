
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerPC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Rigidbody2D playerRB;
    public float speed = 0; 
    public float wallPosition = -1;
    public Vector2 jump =new Vector2(0f, 0f);
    //status
    [SerializeField] bool isGrounded, isSliding;
    //BUffsAndDebuff
    public bool speedDownOn, shieldOn;
    //timers
    public float speedDownTimer, speedDownCounter, shieldTimer, shieldOnCounter;

    void Start()
    {
        speedDownOn = false;
        shieldOn = false;

        shieldTimer = 0;
        speedDownTimer = 0;
    }
    void Update()
    {
        Shield();
        SpeedDown();
        Move(SpeedCalc() * Input.GetAxis("Horizontal"));
        jump = JumpCalc();
        Jump(jump);
    }

    public void Move(float speed)
    {
        if(!isSliding)
            playerRB.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        
    }
    public void Jump(Vector2 jump)
    {
        if ((isSliding || isGrounded) && Input.GetKeyDown("space"))
            playerRB.AddRelativeForce(jump, ForceMode2D.Impulse);

    }
    float SpeedCalc() { float speed = speedDownOn ? 6 : 3; return speed; }

    Vector2 JumpCalc()
    {
        wallPosition = Mathf.Round( Input.GetAxis("Horizontal")) != 0 ? Input.GetAxis("Horizontal") : wallPosition;
        speed = SpeedCalc() * wallPosition * -60;
        Vector2 jumpForce = isSliding ? new Vector2(speed, 200) : new Vector2(0, 200);
        return jumpForce;
    }
    void Shield()
    {
        shieldOn = shieldTimer <= 0 ? false : true;
        this.GetComponentInChildren<Image>().enabled = shieldOn ? true : false;
         shieldOnCounter -= Time.fixedDeltaTime;
        if (shieldOnCounter <= 0)
        {
            shieldTimer = shieldTimer > 0 ? shieldTimer - 1 : 0;
            shieldOnCounter++;
        }
    }
    void SpeedDown()
    {
        speedDownOn = speedDownTimer <= 0 ? false : true;
        playerRB.drag = speedDownOn ? 4 : 1;
        speedDownCounter -= Time.fixedDeltaTime;
        if (speedDownCounter <= 0)
        {
            speedDownTimer = speedDownTimer > 0 ? speedDownTimer - 1 : 0;
            speedDownCounter++;
        }
    }

    void OnCollisionEnter2D(Collision2D elem)
    {
        if (elem.gameObject.tag == "Ground")
        {
            isGrounded = true;
            playerRB.gravityScale = 1;
            if (isSliding)
                isSliding = false;
        }

        if (elem.gameObject.tag == "Wall" && !isGrounded)
        {
            isSliding = true;
            playerRB.gravityScale = 0.5f;
        }
    }
    void OnCollisionExit2D(Collision2D elem)
    {
        if (elem.gameObject.tag == "Ground")
        {
            isGrounded = false;
            playerRB.gravityScale = 10;
        }
        if (elem.gameObject.tag == "Wall")
        { 
            isSliding = false;
            playerRB.gravityScale = 10;

        }
    }
}
