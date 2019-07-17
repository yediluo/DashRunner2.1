using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickUp : MonoBehaviour
{
    [SerializeField] Rigidbody2D myrb;
    [SerializeField] AudioClip PlayerBumpSFX;
    [SerializeField] GameStats GS;
    private void Start()
    {
        GS = FindObjectOfType<GameStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(PlayerBumpSFX, transform.position);
        GS.CoinCount++;

        Destroy(gameObject);
    }



}
