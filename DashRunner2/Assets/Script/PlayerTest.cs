using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;



public class PlayerTest : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float AccelerateMultiplier = 1f;
    [SerializeField] AudioClip PlayerBumpSFX;
    [SerializeField] GameStats gs;


    public int Level;
    public int[] MaxCoinCount;
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
    public float originalSpeed;
    bool canMove;
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
    private void Awake()
    {
        Level = SceneManager.GetActiveScene().buildIndex - 2;
        //   Debug.Log(MaxCoinCount[0]);
        Debug.Log(MaxCoinCount[0].ToString());
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
       if(gs.touchDown)
        {
            for(int i = 0; i<data.LevelInfos.Length; i++)
            {
                    MaxCoinCount[i] = data.LevelInfos[i];
                
            }
            if (MaxCoinCount[Level] < gs.CoinCount) {
                MaxCoinCount[Level] = gs.CoinCount;
            }
            SaveSystem.SavePlayer(this);

        }
        if (isAlive)
        {
            PlayerAnimation();
            PlayerFlip();
            colliderInBounce();

            movingFourWay();
            // movingBasic();
            playerDeath();
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

        Debug.Log("There are currently " + fingers.Count + " fingers touching the screen.");
        if (fingers.Count != 0)
        {
            var x = fingers[0].SwipeScaledDelta.x;
            var y = fingers[0].SwipeScaledDelta.y;
            Debug.Log(fingers[0].SwipeScaledDelta);

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    Debug.Log("Right");
                    directionH = 1;
                }
                else if (x < 0)
                {
                    Debug.Log("Left");
                    directionH = -1;
                }
            }
            else if (Mathf.Abs(x) < Mathf.Abs(y))
            {
                if (y > 0)
                {
                    Debug.Log("Up");
                    directionY = 1;
                }
                else if (y < 0)
                {
                    Debug.Log("Down");
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

                     myAnimator.SetBool("Accelerating", true);

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
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Harzard")))
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
            myAnimator.SetTrigger("Dying");
            rb.bodyType = RigidbodyType2D.Static;
            myBodyCollider.enabled = false;
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
            deathMove();
        }

    }


   /* private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("COntactCOunt: = " + collision.contactCount);


        //Vector2 p = transform.position;

      //  PlayerFlip(collision, p);
    }*/


    //flip the player while changing wallside;
    /*private void PlayerFlip(Collision2D collision, Vector2 p)
    {
        if (collision.contactCount == 4)
        {
            Vector2 cornerPoint = findCornerCollisionPoint(collision);
            // Debug.Log("My corner point is : " + cornerPoint);
            Debug.Log("PlayerState = " + playerPState);
            if (cornerPoint == new Vector2(0, 0))
            { return; }

            //UL x<p.x,y>p.y;
            if (cornerPoint.x < p.x && cornerPoint.y > p.y)
            {
                if (playerPState == "UR" || playerPState == "DL" || playerPState == "DR")
                {
                    isCornerEulerSet = false;
                }
                if (!isCornerEulerSet)
                {
                    if (playerPState == "Up")
                    {

                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 90f);
                    }
                    else if (playerPState == "Left")
                    {

                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - 90f);

                    }
                    else if (playerPState == "Right")
                    {

                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "Idle")
                    {

                        transform.eulerAngles = new Vector3(0f, 0f, 180f);

                    }
                    else if (playerPState == "UR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, -90f);

                    }
                    else if (playerPState == "DL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 180f);

                    }
                    else if (playerPState == "DR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 180f);

                    }
                    isCornerEulerSet = true;
                }


                Debug.Log("I hit the UL");
                playerPState = "UL";
            }
            //UR x>p.x,y>p.y;
            else if (cornerPoint.x > p.x && cornerPoint.y > p.y)
            {
                if (playerPState == "UL" || playerPState == "DL" || playerPState == "DR")
                {
                    isCornerEulerSet = false;
                }
                if (!isCornerEulerSet)
                {

                    if (playerPState == "Up")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - 90f);
                    }
                    else if (playerPState == "Right")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 90f);

                    }
                    else if (playerPState == "Left")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "Idle")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "UL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    }
                    else if (playerPState == "DL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 180f);

                    }
                    else if (playerPState == "DR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 180f);

                    }
                    isCornerEulerSet = true;
                }
                Debug.Log("I hit the UR");
                playerPState = "UR";

            }
            //DL x<p.x,y<p.y;
            else if (cornerPoint.x < p.x && cornerPoint.y < p.y)
            {
                if (playerPState == "UL" || playerPState == "UR" || playerPState == "DR")
                {
                    isCornerEulerSet = false;
                }
                if (!isCornerEulerSet)
                {
                    if (playerPState == "Idle")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - 90f);
                    }
                    else if (playerPState == "Left")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 90f);

                    }
                    else if (playerPState == "Right")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "Up")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "UL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    }
                    else if (playerPState == "UR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    }
                    else if (playerPState == "DR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, -90f);

                    }
                    isCornerEulerSet = true;
                }
                Debug.Log("I hit the DL");
                playerPState = "DL";

            }
            //DR x>p.x,y<p.y;
            else if (cornerPoint.x > p.x && cornerPoint.y < p.y)
            {
                if (playerPState == "UL" || playerPState == "UR" || playerPState == "DL")
                {
                    isCornerEulerSet = false;
                }
                if (!isCornerEulerSet)
                {
                    if (playerPState == "Idle")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 90f);
                    }
                    else if (playerPState == "Right")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - 90f);

                    }
                    else if (playerPState == "Left")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);
                    }
                    else if (playerPState == "Up")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 180f);

                    }
                    else if (playerPState == "UL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    }
                    else if (playerPState == "UR")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    }
                    else if (playerPState == "DL")
                    {
                        transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    }
                    isCornerEulerSet = true;
                }
                Debug.Log("I hit the DR");
                playerPState = "DR";

            }
        }
        // touch the wall not the corner
        else if (collision.contactCount == 2)
        {
            isCornerEulerSet = false;
            Vector2 p1 = collision.GetContact(0).point;
            Vector2 p2 = collision.GetContact(1).point;
            //    Debug.Log("2 collisionCount: with point1 = " + p1 + " point 2 = " + p2);
            //L or R
            if (System.Math.Round(p1.x, 1) == System.Math.Round(p2.x, 1))
            {
                if (p1.x < p.x)
                {
                    playerPState = "Left";
                    Debug.Log("I'm at left wall");
                    transform.eulerAngles = new Vector3(0, 0, -90);
                    if (rb.velocity.y < 0)
                    {
                        transform.localScale = new Vector2(0.8f, 0.8f);
                    }
                    else
                    {
                        transform.localScale = new Vector2(-0.8f, 0.8f);

                    }
                }
                else if (p1.x > p.x)
                {
                    playerPState = "Right";

                    Debug.Log("I'm at Right wall");
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    if (rb.velocity.y < 0)
                    {
                        transform.localScale = new Vector2(-0.8f, 0.8f);
                    }
                    else
                    {
                        transform.localScale = new Vector2(0.8f, 0.8f);

                    }
                }
            }
            // U or D
            else if (System.Math.Round(p1.y, 1) == System.Math.Round(p2.y, 1))
            {

                if (p1.y > p.y)
                {
                    playerPState = "Up";

                    Debug.Log("Im at Up wall");
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    if (rb.velocity.x < 0)
                    {
                        transform.localScale = new Vector2(0.8f, 0.8f);
                    }
                    else
                    {
                        transform.localScale = new Vector2(-0.8f, 0.8f);

                    }
                }
                else if (p1.y < p.y)
                {
                    playerPState = "Idle";

                    Debug.Log("im at Down Wall");
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    // flip when facing left;
                    if (rb.velocity.x < 0)
                    {
                        transform.localScale = new Vector2(-0.8f, 0.8f);
                    }
                    else
                    {
                        transform.localScale = new Vector2(0.8f, 0.8f);

                    }
                }

            }
        }
    }
    */


    //locate the corner point;
  /*  private Vector2 findCornerCollisionPoint(Collision2D collision)
    {
        Vector2 p = new Vector2();
        collisionCount++;
       // Debug.Log("contactCount" + collisionCount + ": = " + collision.contactCount);
        for (int i = 0; i < collision.contactCount; i++)
        {
           // Debug.Log("contactCount" + "["+i+"]" + collisionCount + ": = " + collision.GetContact(i).point);
            for (int j = i+1; j < collision.contactCount; j++)
            {
                bool isSamePoint = (System.Math.Round(collision.GetContact(i).point.x, 1) == System.Math.Round(collision.GetContact(j).point.x, 1))
                                    && (System.Math.Round(collision.GetContact(i).point.y, 1) == System.Math.Round(collision.GetContact(j).point.y, 1));


                if (isSamePoint)
                {
                //    Debug.Log("my point is :" + collision.GetContact(i).point);
                    p = collision.GetContact(i).point;
                    return p;

                }
            }

        }
        return p;
    }
    
*/

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
}

