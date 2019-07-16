using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canno : MonoBehaviour
{

    public Rigidbody2D fireball;
    public float fireballSpeed;


    //assist var
    public float timeBefore;
    
    // Start is called before the first frame update
    void Start()
    {
        timeBefore = Time.time;
        fireballSpeed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        shootEachSecond();
    }

    private void shootEachSecond()
    {
        if (Time.time - timeBefore >= 1)
        {
            var fireballInst = Instantiate(fireball, new Vector2(transform.position.x,transform.position.y-0.5f), Quaternion.Euler(new Vector2(0, 0)));
            fireballInst.velocity = new Vector2(0f, -fireballSpeed);
            timeBefore = Time.time;
        }
    }
}
