using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShow : MonoBehaviour
{
    [SerializeField] PlayerTest mypl;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D playerRb = mypl.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
