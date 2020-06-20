using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3vwhole : MonoBehaviour
{

    BoxCollider2D mybcd;
    [SerializeField] float size;
    [SerializeField] GameObject explosionPrefab;


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
         //   mybcd.size = new Vector2(1f, 1f);
            beginTime = currentTime;
            isExploded = false;

        }
        else if ((currentTime - beginTime) >= 2)
        {

            if (!isExploded)
            {

                //                mybcd.size = new Vector2(1f, size);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                for (int i = 1; i <= size/2; i++)
                {
                    Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y+i), Quaternion.identity);
                    Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y-i), Quaternion.identity);

                }


                isExploded = true;
            }

        
        }

    }
}

