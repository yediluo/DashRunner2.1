using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1loop : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myrb;
    BoxCollider2D mybcd;


    //assist var
    //avoid debounce
    float debounceBeginTime;

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        mybcd = GetComponent<BoxCollider2D>();
        myrb.velocity = new Vector2(speed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<PlayerTest>().isAlive)
        {
            Destroy(gameObject);
        }
        /*      if(mybcd.IsTouchingLayers(LayerMask.GetMask("Player")))
              {
                  Destroy(gameObject);
              }*/
        //Debug.Log("rotation + = " + transform.rotation.eulerAngles);

       // Debug.Log("quarternion + = " + Quaternion.Euler(0,0,180));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Player"&& excuteAfterTime(debounceBeginTime, 1))
        {


            if(QuaternionsEqual(transform.rotation,Quaternion.Euler(0,0,0), 0.0000004f))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                myrb.velocity = new Vector2(0f, -speed);


            }
            else if (QuaternionsEqual(transform.rotation, Quaternion.Euler(0, 0, -90),0.0000004f))
            {
                //Debug.Log("match quaternion2");
                Debug.Log(transform.rotation);
                this.transform.rotation = Quaternion.Euler(0, 0, 180);
                myrb.velocity = new Vector2(-speed, 0f);



            }
            else if (QuaternionsEqual(transform.rotation, Quaternion.Euler(0, 0, 180), 0.0000004f))
            {
               // Debug.Log("match quaternion3");
                transform.rotation = Quaternion.Euler(0, 0, 90);
                myrb.velocity = new Vector2(0f, speed);



            }
            else if (QuaternionsEqual(transform.rotation, Quaternion.Euler(0, 0, 90), 0.0000004f))
            {
                //Debug.Log("match quaternion4");
                transform.rotation = Quaternion.Euler(0, 0, 0);
                myrb.velocity = new Vector2(speed,0f);

            }
            debounceBeginTime = Time.time;


        }
    }


    public static bool QuaternionsEqual(Quaternion q1, Quaternion q2, float precision)
    {
        return Mathf.Abs(Quaternion.Dot(q1, q2)) >= 1 - precision;
    }


    public bool excuteAfterTime(float beginTime, float waitTime)
    {
        if ((Time.time - beginTime) >= waitTime)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
