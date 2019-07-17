using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/// <summary>
/// for all the UI and interface transition, reload scene etc
/// 
/// </summary>
public class GameStats : MonoBehaviour
{
    [SerializeField] Image [] coinsInGame;

    [SerializeField] Image [] coins;
    [SerializeField] GameObject pa;
    [SerializeField] PlayerTest player;
    [SerializeField] Text timeLeft;
    public int CoinCount;
    public string sceneName;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerTest>();
       sceneName = SceneManager.GetActiveScene().name;
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit();
        Debug.Log("coincount= " + CoinCount);
        if(CoinCount > 2)
        {
            coinsInGame[0].color = new Vector4(255, 255, 255, 255);
            coinsInGame[1].color = new Vector4(255, 255, 255, 255);
            coinsInGame[2].color = new Vector4(255, 255, 255, 255);

        }
        else if (CoinCount > 1) {
            coinsInGame[0].color = new Vector4(255, 255, 255, 255);
            coinsInGame[1].color = new Vector4(255, 255, 255, 255);


        }
        else if (CoinCount > 0) {

            coinsInGame[0].color = new Vector4(255, 255, 255, 255);
        }
    }

    
    public void deathPanel()
    {
        //display panel
        pa.SetActive(true);

        //disable coiningame and  time text;
        timeLeft.enabled = false;

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

    public void timeLimit()
    {
        if ((Time.time - currentTime) < 15)
        {
            Debug.Log("Time+ = " + (Time.time - currentTime));
            timeLeft.text = ("TimeLeft: = " + (Time.time - currentTime));
        }
        else
        {
            if (player.isAlive)
            {
                timeLeft.text = ("TimeLeft: = " + (Time.time - currentTime));

                player.deathMove();
            }
           
        }
    }
}
