using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] PlayerTest p;
    [SerializeField] Vector2 destination;
    [SerializeField] AudioClip PortalSFX;

    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<PlayerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player")
        {
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

            p.transform.position = destination;
            p.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            AudioSource.PlayClipAtPoint(PortalSFX, transform.position);
        }
    }
}
