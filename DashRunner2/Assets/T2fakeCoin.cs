using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2fakeCoin : MonoBehaviour
{
    Animator myAC;
    private void Start()
    {
        myAC = GetComponent<Animator>();
    }
    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "Player")
          {
              AudioSource.PlayClipAtPoint(PlayerBumpSFX, transform.position);

              GS.CoinCount++;

              Destroy(gameObject);
          }
      }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            //trigger coin death animation;
            myAC.SetTrigger("active");
            
        }
    }



}
