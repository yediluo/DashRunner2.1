using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D myRigidBody;
    bool facingUp = true;

    // Start is called before the first frame update
    void Start()
    {

        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingUp())
        {
            myRigidBody.velocity = new Vector2(moveSpeed,0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed,0f);

        }
    }

    bool isFacingUp()
    {
        return facingUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       
        if(collision.tag!="Player")
        {
            //transform.localScale = new Vector2(1f, -(Mathf.Sign(myRigidBody.velocity.y)));
            facingUp = !facingUp;
        }
    }

    //let player move on elevator on a local scale
}
