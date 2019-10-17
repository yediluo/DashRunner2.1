using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;



public class PlayerTest : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float AccelerateMultiplier;
    [SerializeField] AudioClip AccelerationSFX;
    [SerializeField] AudioClip DeathSFX;
    [SerializeField] GameObject invC;
    [SerializeField] GameObject handcuff; 
    GameStats gs;


    public int Level;
    public int[] MaxCoinCount;
    public int maxLevel;
    public Rigidbody2D rb;
    public BoxCollider2D myBodyCollider;
    public Animator myAnimator;
     

    //state
    private float t = 0.0f;
    private bool moving = false;
    float directionH;
    float directionY;
    public bool isAlive = true;
    String playerPState = "Idle";


    //assist para

    public Button Dbug;
    public float originalSpeed;
    public bool canMove;
    Vector2 bounceTempSpeed;
    //bool leftBouncer = true;
    bool leftBouncerDL = true;
    bool leftBouncerDR = true;
    bool leftBouncerUL = true;
    bool leftBouncerUR = true;
   // int collisionCount = 0;
    bool isCornerEulerSet = false;
  //  bool isAccelerating = false;
    public bool canPlayBump = false;
    public PlayerData data;
    //for freezePoint
    bool freezeP = false;
    float freezeBeginTime;

    //for invincible pill;
    bool invincible = false;
    float invincibleBeginTime = 0;
    public int T5invincibleTIme;

    private void Awake()
    {

        Level = SceneManager.GetActiveScene().buildIndex - 3;
        if(SceneManager.GetActiveScene().name == "LevelS") {
            Level = SceneManager.GetActiveScene().buildIndex - 4;
        }

       // Debug.Log(MaxCoinCount[0].ToString());
        data = SaveSystem.LoadPlayer();
    }
    void Start()
    {
        originalSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        gs = FindObjectOfType<GameStats>();
    }

    void Update()
    {

        //start the saving system
        //level S and start menu do not trigger save system; 
        if(SceneManager.GetActiveScene().buildIndex - 3 >= 0&&SceneManager.GetActiveScene().name != "LevelS") {
        //save playerData
       if(gs.touchDown)
        {
            
            for(int i = 0; i<data.LevelInfos.Length; i++)
            {
                    MaxCoinCount[i] = data.LevelInfos[i];
                         
            }
            if (MaxCoinCount[Level] < gs.CoinCount) {
                MaxCoinCount[Level] = gs.CoinCount;
            }

            
            if(data.CurrentLevel < Level)
            {
                maxLevel = Level;
            }else
            {
                maxLevel = data.CurrentLevel;
            }
            SaveSystem.SavePlayer(this);

        }
       //saving system done
       
        }
        if (isAlive)
        {
            //freezePoint bodytypechange
            if(freezeP)
            {
                Debug.Log("freezeTIme: " + (freezeBeginTime));
                directionH = 0;
                directionY = 0;
                if(excuteAfterTime(freezeBeginTime,0.5f)) {
                    movingFourWay();

                    freezeBeginTime = 0;
                    freezeP = false;
                }
                
            }else
            {
                movingFourWay();

            }
            PlayerAnimation();
            PlayerFlip();
            colliderInBounce();

            // movingBasic();
            if (invincible)
            {
                if(excuteAfterTime(invincibleBeginTime, T5invincibleTIme))
                {

                    playerDeath();
                    invC.SetActive(false);
                    invincibleBeginTime = 0;
                    invincible = false;
                }
            }
            else
            {
                playerDeath();
            }
        }
        else
        {

                //SceneManager.LoadScene("GameOver");
                // pa.SetActive(true);
                gs.deathPanel();

        }
    }

    public void touchControl()
    {
        var fingers = Lean.Touch.LeanTouch.Fingers;

       // Debug.Log("There are currently " + fingers.Count + " fingers touching the screen.");
        if (fingers.Count != 0)
        {
            var x = fingers[0].SwipeScaledDelta.x;
            var y = fingers[0].SwipeScaledDelta.y;
         //   Debug.Log(fingers[0].SwipeScaledDelta);

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                 //   Debug.Log("Right");
                    directionH = 1;
                }
                else if (x < 0)
                {
                //    Debug.Log("Left");
                    directionH = -1;
                }
            }
            else if (Mathf.Abs(x) < Mathf.Abs(y))
            {
                if (y > 0)
                {
                 //   Debug.Log("Up");
                    directionY = 1;
                }
                else if (y < 0)
                {
                  //  Debug.Log("Down");
                    directionY = -1;
                }
            }
        }
    }
    private void PlayerAnimation()
    {
 
            if (canMove)
            {
                myAnimator.SetBool("Running", false);
            }
            else
            {
                myAnimator.SetBool("Running", true);
                if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) > (originalSpeed + 10))
                {
                     //myAnimator.SetBool("Running", true);
                    if(myAnimator.GetBool("Accelerating") == false) {

                     myAnimator.SetBool("Accelerating", true);
                    AudioSource.PlayClipAtPoint(AccelerationSFX, this.transform.position);
                    }

                }else
                {
                     myAnimator.SetBool("Accelerating", false);

                    // myAnimator.SetBool("Running", true);


                }

        }
       


    }

    private void PlayerFlip()
    {
        if (canMove)
        {
            if (directionH > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 90f);
            }
            else if (directionH < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, -90f);
            }
            else if (directionY > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 180f);

            }
            else if (directionY < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0f);

            }
        }
        else if (withinBouncing())
        {

            if (rb.velocity.x > 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 90f);
            }
            else if (rb.velocity.x < -1)
            {
                transform.eulerAngles = new Vector3(0, 0, -90f);
            }
            else if (rb.velocity.y > 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 180f);

            }
            else if (rb.velocity.y < -1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0f);

            }
        }
    }

    public void movingFourWay()
    {

        //check if player touched new wall
  /*      bool isOriginalSpeed = Mathf.Approximately(Mathf.Round(Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)), originalSpeed);
        bool isAcceleratedSpeed = Mathf.Approximately(Mathf.Round(Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)), speed);
        bool isLessThanOriginalSpeed = originalSpeed > (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
        if (!isOriginalSpeed && !isAcceleratedSpeed && isLessThanOriginalSpeed)
        {
            canMove = true;
            if (!withinBouncing())
            {

                movingBasic();
            }
        } else
        {
            canMove = false;
        }
        */
        if(Mathf.Abs(rb.velocity.x) > 1  ||Mathf.Abs(rb.velocity.y) > 1)
        {
            canMove = false;
        }else
        {
            canMove = true;
            if(!withinBouncing())
            {
                movingBasic();

            }
        }

    }

    private void movingBasic()
    {
        
        directionH = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        //touch control replace the keyentry;
        touchControl();
       
       /* Touch touch = Input.GetTouch(0);
        float directionHT = touch.deltaPosition.x;
        float directionYT = touch.deltaPosition.y;
        //checktouch enabled or not;
        if (Input.touchCount == 2)
        {
            directionH = directionHT;
            directionY = directionYT;
        }*/
        if (directionH > 0)
        {

            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector2(speed, 0);
            moving = true;
            //       Debug.Log("jump");
        }
        else if (directionH < 0)
        {
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector2(-1 * speed, 0);
            moving = true;
        }

        else if (directionY > 0)
        {
            rb.velocity = new Vector2(0, speed);

        }
        else if (directionY < 0)
        {
            rb.velocity = new Vector2(0, -1 * speed);

        }
    }

    public void playerDeath()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Harzard","Bullet")))
        {
            deathMove();
        }
    }

    public void deathMove()
    {
        // win then no more timelimit death
        if (!gs.touchDown)
        {
            isAlive = false;
            AudioSource.PlayClipAtPoint(DeathSFX, this.transform.position);

            myAnimator.SetTrigger("Dying");
            rb.bodyType = RigidbodyType2D.Static;
            myBodyCollider.enabled = false;
            FindObjectOfType<Foot>().GetComponent<BoxCollider2D>().enabled = false;
            
        }

    }

    //check if the player is caught in the middle of the bounce
    public bool withinBouncing()
    {
        //not inside the trigger

        if (leftBouncerDL && leftBouncerDR && leftBouncerUL && leftBouncerUR)
        {
            if (canMove)
            {
                return false;
            }
        }
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "AccelerateGround")
        {
            speed = speed * AccelerateMultiplier;
            rb.velocity = new Vector2(rb.velocity.x * AccelerateMultiplier, rb.velocity.y * AccelerateMultiplier);
           // isAccelerating = true;
           // myAnimator.SetBool("Accelerating", true);

        }
        if (collision.gameObject.tag == "Bullet")
        {
            if (!invincible)
            {
                deathMove();

            }
        }



    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AccelerateGround")
        {
            speed = Mathf.RoundToInt(speed / AccelerateMultiplier);
            rb.velocity = new Vector2(rb.velocity.x / AccelerateMultiplier, rb.velocity.y / AccelerateMultiplier);
           // myAnimator.SetBool("Accelerating",false);
           // isAccelerating = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BounceDL")
        {
            bounceTempSpeed = new Vector2(-rb.velocity.y, -rb.velocity.x);
           // bouncing = true;
            leftBouncerDL = false;

        }else if(collision.tag == "BounceUR")
        {
            bounceTempSpeed = new Vector2(-rb.velocity.y, -rb.velocity.x);
            // bouncing = true;
            leftBouncerUR = false;
        }
        else if (collision.tag == "BounceDR")
        {
            bounceTempSpeed = new Vector2(rb.velocity.y, rb.velocity.x);
            leftBouncerDR = false;


        }else if(collision.tag == "BounceUL")
        {
            bounceTempSpeed = new Vector2(rb.velocity.y, rb.velocity.x);
            leftBouncerUL = false;
        }

        if(collision.tag == "E4slow")
        {
            handcuff.SetActive(true);
            speed = 10;
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x)*10,0);
            }else if(Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
            {
                rb.velocity = new Vector2(0,Mathf.Sign(rb.velocity.y) * 10);

            }


        }
        if (collision.tag == "E4restore")
        {
            handcuff.SetActive(false);
            speed = originalSpeed;
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * originalSpeed, 0);
            }
            else if (Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
            {
                rb.velocity = new Vector2(0, Mathf.Sign(rb.velocity.y) * originalSpeed);

            }


        }

        if(collision.tag == "T3freezePoint")
        {
            rb.velocity = new Vector2(0, 0);
            freezeBeginTime = Time.time;

            freezeP = true;
            this.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1);
        }
        if (collision.tag == "T3freezePointR")
        {

            rb.velocity = new Vector2(0, 0);
            //disable player controll;
           // rb.bodyType = RigidbodyType2D.Static;
            //start a timer for 0,5 s
            freezeBeginTime = Time.time;

            freezeP = true;

            this.transform.position = new Vector2(collision.transform.position.x-1, collision.transform.position.y);

        }
        if (collision.tag == "T3freezePointL")
        {
            rb.velocity = new Vector2(0, 0);
            freezeBeginTime = Time.time;

            freezeP = true;
            this.transform.position = new Vector2(collision.transform.position.x+1, collision.transform.position.y);
        }
        if (collision.tag == "T3freezePointUp")
        {
            rb.velocity = new Vector2(0, 0);
            freezeBeginTime = Time.time;

            freezeP = true;
            this.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y - 1);
        }

        if(collision.tag == "T5Invincible")
        {
            invincibleBeginTime = Time.time;
            invincible = true;
            invC.SetActive(true);

            
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (canMove)
        {
            //  Debug.Log("BounceTempSpeed: = " + bounceTempSpeed);

            rb.velocity = new Vector2(Mathf.RoundToInt(bounceTempSpeed.x), Mathf.RoundToInt(bounceTempSpeed.y));
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BounceDL")
        {
            leftBouncerDL = true;
        }
        if (collision.tag == "BounceUR")
        {
            leftBouncerUR = true;

        }
        if(collision.tag == "BounceDR")
        {
            leftBouncerDR = true;
        }
        if(collision.tag == "BounceUL")
        {
            leftBouncerUL = true;
        }
    }

   /* public void PlayBump()
    {
        if (canMove)
        {
            if (canPlayBump)
            {
                AudioSource.PlayClipAtPoint(PlayerBumpSFX, transform.position);
                canPlayBump = false;
            }
        } else
        {
            canPlayBump = true;
        }
    }*/

        //change colliderside within Bounce, prevent stuck;
    public void colliderInBounce()
    {
        if (withinBouncing()) {
             myBodyCollider.size = new Vector2(1f,1f);
        }else
        {

            myBodyCollider.size = new Vector2(0.48f, 1f);
        }
    }


    public bool excuteAfterTime(float beginTime, float waitTime)
    {
       if((Time.time - beginTime)>=waitTime) 
        {
            return true;
        }else
        {
            return false;
        }
       
    }
}

