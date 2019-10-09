using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6entire : MonoBehaviour
{

    BoxCollider2D mybcd;
    [SerializeField] Vector2 size;

    //assist var
    float beginTime;
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
        if ((currentTime - beginTime) >= 3)
        {
            mybcd.size = new Vector2(1f, 1f);
            beginTime = currentTime;
        }
        else if ((currentTime - beginTime) >= 2)
        {
            mybcd.size = size;
        }

    }
}

