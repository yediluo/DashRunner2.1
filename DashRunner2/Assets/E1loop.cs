using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1loop : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myrb;
    BoxCollider2D mybcd;
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Mathf.Approximately(myrb.velocity.x, 0))
        {
            if (myrb.velocity.y > 0)
            {
                myrb.velocity = new Vector2(speed, 0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);

              //  mybcd.size = new Vector2(1f, 0.5f);

            }
            else if (myrb.velocity.y < 0)
            {
                myrb.velocity = new Vector2(-speed, 0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 180);

                // mybcd.size = new Vector2(1f, 0.5f);
            }
        }
        else
        {
            if(myrb.velocity.x > 0)
            {
                myrb.velocity = new Vector2(0f,-speed);
                this.transform.rotation = Quaternion.Euler(0, 0, -90);

                // mybcd.size = new Vector2(0.5f, 1f);
            }
            else if (myrb.velocity.x < 0)
            {
                myrb.velocity = new Vector2(0f,speed);
                this.transform.rotation = Quaternion.Euler(0, 0, 90);

                // mybcd.size = new Vector2(0.5f, 1f);
            }
        }

    }
}
