using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2explode : MonoBehaviour
{

    BoxCollider2D mybcd;
    [SerializeField] GameObject explosionPrefab ;

    //assist var
    float beginTime;
    bool isExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        mybcd = GetComponent<BoxCollider2D>();
        beginTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup;
        if ((currentTime - beginTime) >= 4)
        {
           // mybcd.size = new Vector2(1f, 1f);
            beginTime = currentTime;
            isExploded = false;

        }
        else if ((currentTime - beginTime) >=2) {
          //  mybcd.size = new Vector2(2.5f, 2.5f);
            if(!isExploded) {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x+1,transform.position.y), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y+1), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y-1), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x+1, transform.position.y + 1), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x + 1, transform.position.y - 1), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity);
                Instantiate(explosionPrefab, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);


                isExploded = true;


           }

        }

    }
}

