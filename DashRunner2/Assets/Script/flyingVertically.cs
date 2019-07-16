using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingVertically : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myrb;
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        myrb.velocity = new Vector2(0f, speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(myrb.velocity.y > 0)
        {
            myrb.velocity = new Vector2(0f,-speed);
        }else
        {
            myrb.velocity = new Vector2(0f, speed);
        }
    }
}
