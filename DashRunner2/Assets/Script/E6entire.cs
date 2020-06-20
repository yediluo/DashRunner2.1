using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6entire : MonoBehaviour
{

    BoxCollider2D mybcd;
    SpriteRenderer mysr;
    [SerializeField] new Vector2Int size;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Sprite bombOn;
    [SerializeField] Sprite bombOff;



    //assist var
    float beginTime;
    bool isExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        mybcd = GetComponent<BoxCollider2D>();
        mysr = GetComponent<SpriteRenderer>();
        beginTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup;
        if ((currentTime - beginTime) >= 4)
        {
            //   mybcd.size = new Vector2(1f, 1f);
            mysr.sprite = bombOff;
            beginTime = currentTime;
            isExploded = false;

        }
        else if ((currentTime - beginTime) >= 2)
        {

            if (!isExploded)
            {

                //                mybcd.size = new Vector2(1f, size);
                //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                mysr.sprite = bombOn;
                for (int i = 0; i < size.y;i++)
                {
                    for (int j = 0; j < size.x; j++)
                    {

                        Instantiate(explosionPrefab, new Vector2((transform.position.x-size.x/2) + j, (transform.position.y-size.y/2)+i), Quaternion.identity);
                        //Instantiate(explosionPrefab, new Vector2(transform.position.x - j, (transform.position.y - size.y / 2) + i), Quaternion.identity);

                    }
                }
                


                isExploded = true;
            }


        }

    }
}

