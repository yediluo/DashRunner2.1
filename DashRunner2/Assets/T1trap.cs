using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1trap : MonoBehaviour
{
    [SerializeField] GameObject spike;
    bool startCount = false;
    float beginTime;
    bool spikeUp = false;
    private void Update()
    {
        if(startCount)
        {
            if ((Time.time - beginTime) >= 2)
            {
                spike.SetActive(false);
                startCount = false;
            }
            else if ((Time.time - beginTime)>=1) {
                //initiate spike on top
                spike.SetActive(true);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!startCount)
        {
            if (collision.gameObject.tag == "Player")
            {
                beginTime = Time.time;

                startCount = true;
            }
        }
    }

    


}
