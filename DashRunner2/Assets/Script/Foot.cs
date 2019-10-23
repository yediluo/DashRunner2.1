using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] AudioClip PlayerBumpSFX;
    AudioSource audioSource;
    SimpleCameraShakeInCinemachine cs;
    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        cs = FindObjectOfType<SimpleCameraShakeInCinemachine>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        audioSource.PlayOneShot(PlayerBumpSFX, 1.0f);


        if (collision.tag == "Ground" || collision.tag == "AccelerateGround"||collision.tag == "T1trap" || collision.tag == "BounceUL" || collision.tag == "BounceUR" || collision.tag == "BounceDL" || collision.tag == "BounceDR")
         
        {
//            audioSource.PlayOneShot(PlayerBumpSFX, 1.0f);
            

            if (cs != null)
            {
                cs.doshake = true;
            }
        }
    }
}
