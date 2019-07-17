using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    [SerializeField] Image coin1;
    [SerializeField] Image coin2;
    [SerializeField] Image coin3;
    public int CoinCount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("coincount= " + CoinCount);
        if(CoinCount > 2)
        {
            coin3.color = new Vector4(255, 255, 255, 255);
            coin2.color = new Vector4(255, 255, 255, 255);
            coin1.color = new Vector4(255, 255, 255, 255);

        }
        else if (CoinCount > 1) {
            coin2.color = new Vector4(255, 255, 255, 255);
            coin1.color = new Vector4(255, 255, 255, 255);


        }
        else if (CoinCount > 0) {

            coin1.color = new Vector4(255, 255, 255, 255);
        }
    }
}
