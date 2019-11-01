using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public CircleCollider2D myBodyCollider;
    private void Start()
    {
        myBodyCollider = GetComponent<CircleCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Canno")|| collision.gameObject.CompareTag("T1trap"))
        {
            Destroy(gameObject);
        }
    } 
}
