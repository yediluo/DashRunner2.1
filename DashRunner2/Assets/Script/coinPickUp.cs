using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickUp : MonoBehaviour
{
    [SerializeField] Rigidbody2D myrb;
    [SerializeField] AudioClip PlayerBumpSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(PlayerBumpSFX, transform.position);
        Destroy(gameObject);
    }
}
