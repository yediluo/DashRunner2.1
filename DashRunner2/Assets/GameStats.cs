using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] Image coin1;
    [SerializeField] Image coin2;
    [SerializeField] Image coin3;
    public int CoinCount;
    // Start is called before the first frame update
    void Start()
    {
       
=======
    [SerializeField] Image [] coinsInGame;

    [SerializeField] Image [] coins;
    [SerializeField] GameObject pa;
    public int CoinCount;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
       sceneName = SceneManager.GetActiveScene().name;

<<<<<<< HEAD
>>>>>>> parent of 0ceb4c3... Timelimit 15 second prototype
=======
>>>>>>> parent of 0ceb4c3... Timelimit 15 second prototype
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

<<<<<<< HEAD
            coin1.color = new Vector4(255, 255, 255, 255);
        }
    }
=======
            coinsInGame[0].color = new Vector4(255, 255, 255, 255);
        }
    }

    
    public void deathPanel()
    {
        //display panel
        pa.SetActive(true);
        //disable coiningame;
        coinsInGame[0].enabled = false;
        coinsInGame[1].enabled = false;
        coinsInGame[2].enabled = false;
        //show coin in panel;
        if (CoinCount > 2)
        {
            coins[0].color = new Vector4(255, 255, 255, 255);
            coins[1].color = new Vector4(255, 255, 255, 255);
            coins[2].color = new Vector4(255, 255, 255, 255);

        }
        else if (CoinCount > 1)
        {
            coins[1].color = new Vector4(255, 255, 255, 255);
            coins[0].color = new Vector4(255, 255, 255, 255);


        }
        else if (CoinCount > 0)
        {

            coins[0].color = new Vector4(255, 255, 255, 255);
        }


    }
<<<<<<< HEAD
>>>>>>> parent of 0ceb4c3... Timelimit 15 second prototype
=======
>>>>>>> parent of 0ceb4c3... Timelimit 15 second prototype
}
