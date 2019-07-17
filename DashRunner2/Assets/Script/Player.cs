using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;

    void Start()
    {
        target = new Vector2(9f,transform.position.y);
        position = gameObject.transform.position;
        speed = 150;
        cam = Camera.main;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        // compute where the mouse is in world space
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // set the target to the mouse click location
            target = point;
        }
    }

    /*
    //config
    [SerializeField] float speed=10f;
    [SerializeField] Rigidbody2D myrb;
    // parameter 
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Running();
    }


    void Running()
    {
        //running from point A to point B
        //constant speed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Im in");
            Vector2 target = new Vector2
                (10,transform.position.y);
            transform.position = Vector2.MoveTowards
                    (transform.position, target, speed * Time.deltaTime);

        }
    }
    */
}
