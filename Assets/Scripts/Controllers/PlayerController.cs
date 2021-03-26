using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D userRB2D;
    public float cooldown;
    public float speed,speedDownTimer,timeDown,timeShield, shieldOnTimer,timer;
    [SerializeField] bool isGrounded = false, isSliding = false;
    public bool isShieldOn = false, speedTimerOn = false;
    [SerializeField] Vector2 jump;
    Joystick joystick;
    void Start()
    {   
        userRB2D = this.gameObject.GetComponent<Rigidbody2D>();
        speedDownTimer = 0;
        shieldOnTimer = 0;
        timeDown = 1;
        timeShield = 1;
        speed = 7;
        joystick = FindObjectOfType<Joystick>();
        cooldown = 0;
        timer = 0.25f;
    }
    void FixedUpdate()
    {

        SpeedDown();
        Shield();
        //Move(CrossPlatformInputManager.GetAxis(joystick.horizontalAxisName)*speed);
        //Jump(CrossPlatformInputManager.GetAxis(joystick.horizontalAxisName) * speed)C);
        Move(Input.GetAxisRaw("Horizontal") * speed);
        Jump(Input.GetAxisRaw("Horizontal") * speed);

    }
    void Move(float finalSpeed)
    {
        finalSpeed = isGrounded ? finalSpeed : finalSpeed / 2;
        userRB2D.AddForce(new Vector2(finalSpeed, 0), ForceMode2D.Impulse);
        if (finalSpeed < 0)
            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
        if (finalSpeed > 0)
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;

    }
    void Jump(float speedJump)
    {
        jump = isSliding  ? new Vector2(speedJump / 2, 200) : new Vector2(speedJump, 300);
        jump = speedTimerOn ? jump / 2 : jump;
        if (CrossPlatformInputManager.GetButton("Jump") && (isGrounded || isSliding))
        {
            userRB2D.AddRelativeForce(jump, ForceMode2D.Impulse);
            cooldown = 1f;
        }
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            cooldown = cooldown > 0 ? cooldown - 0.25f : 0;
            timer = 0.25f;
        }
    }
    void Shield()
    {
        isShieldOn = shieldOnTimer <= 0 ? false : true;
        this.GetComponentInChildren<Image>().enabled = isShieldOn ? true : false;
        timeShield -= Time.fixedDeltaTime;
        if (timeShield <= 0)
        {
            shieldOnTimer = shieldOnTimer > 0 ? shieldOnTimer - 1 : 0;
            timeShield++;
        }
    }
    void SpeedDown()
    {
        speedTimerOn = speedDownTimer <= 0 ? false : true;
        userRB2D.drag = speedTimerOn ? 4 : 1;
        jump = !speedTimerOn ? new Vector2(0,220)  : new Vector2(0,320);
        timeDown -= Time.fixedDeltaTime;
        if (timeDown <= 0)
        {
            speedDownTimer = speedDownTimer > 0 ? speedDownTimer - 1 : 0;
            timeDown++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;

            userRB2D.gravityScale = 1.0f;
            userRB2D.drag = 1;
        }
        if(other.gameObject.tag == "Wall" && !isGrounded)
        {
            isSliding = true;
            userRB2D.gravityScale = 1.0f;
            userRB2D.drag = 1;

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;

            userRB2D.gravityScale = 10.0f;
            userRB2D.drag = 3;
        }
        if(other.gameObject.tag == "Wall")
        {
            isSliding = false;
            userRB2D.gravityScale = 10.0f;
            userRB2D.drag = 3;
        }
    }



}
