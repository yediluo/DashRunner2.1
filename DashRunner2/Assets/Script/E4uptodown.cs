using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4uptodown : MonoBehaviour
{

    public Rigidbody2D fireball;
    public float fireballSpeed;
    

    //assist var
    public float timeBefore; // for bullet;
    public float beginTime; //for apearance;
    // Start is called before the first frame update
    void Start()
    {
        timeBefore = Time.time;
        beginTime = Time.time;
        fireballSpeed = 10f;
       // this.transform.position =new Vector2(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        apearEach5s();
        //Debug.Log(Time.time);
        shootEachSecond();
    }

    private void shootEachSecond()
    {
        if (Time.time - timeBefore >= 1)
        {
            var fireballInst = Instantiate(fireball, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.Euler(new Vector2(0, 0)));
            fireballInst.velocity = new Vector2(0f, -fireballSpeed);
            timeBefore = Time.time;
        }
    }

    private void apearEach5s()
    {
        if(Time.time-beginTime >= 5)
        {
            this.transform.position = new Vector2(Camera.main.gameObject.transform.position.x+2, Camera.main.gameObject.transform.position.y+5);

        }
    }
}
