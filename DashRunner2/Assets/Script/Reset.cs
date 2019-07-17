using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D myBodyCollider;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0.5f, 0.5f, 0);
            rb.velocity = new Vector2(0, 0);

        }
    }
}
