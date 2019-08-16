using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] AudioClip PlayerBumpSFX;
    SimpleCameraShakeInCinemachine cs;
    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        cs = FindObjectOfType<SimpleCameraShakeInCinemachine>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "AccelerateGround")
         
        {
            AudioSource.PlayClipAtPoint(PlayerBumpSFX, transform.position);
            if (cs != null)
            {
                cs.doshake = true;
            }
        }
    }
}
