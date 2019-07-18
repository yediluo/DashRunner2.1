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
    //config
    [SerializeField] Image[] coinsInWinPanel;

    //ingame coin 
    [SerializeField] Image [] coinsInGame;
    //deathpanel coin 
    [SerializeField] Image [] coinsInDeathPanel;
    [SerializeField] GameObject deathPa;
    [SerializeField] GameObject winPa;
    [SerializeField] Text timeLeft;
    [SerializeField] float timeMax;


    //support

    PlayerTest player;
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




    public void winPanel() {
        winPa.SetActive(true);

        //disable coiningame and  time text;
        timeLeft.enabled = false;

        coinsInGame[0].enabled = false;
        coinsInGame[1].enabled = false;
        coinsInGame[2].enabled = false;
        //show coin in panel;
        if (CoinCount > 2)
        {
            coinsInWinPanel[0].color = new Vector4(255, 255, 255, 255);
            coinsInWinPanel[1].color = new Vector4(255, 255, 255, 255);
            coinsInWinPanel[2].color = new Vector4(255, 255, 255, 255);

        }
        else if (CoinCount > 1)
        {
            coinsInWinPanel[1].color = new Vector4(255, 255, 255, 255);
            coinsInWinPanel[0].color = new Vector4(255, 255, 255, 255);


        }
        else if (CoinCount > 0)
        {

            coinsInWinPanel[0].color = new Vector4(255, 255, 255, 255);
        }


    }

    public void deathPanel()
    {
        //display panel
        deathPa.SetActive(true);

        //disable coiningame and  time text;
        timeLeft.enabled = false;

        coinsInGame[0].enabled = false;
        coinsInGame[1].enabled = false;
        coinsInGame[2].enabled = false;
        //show coin in panel;
        if (CoinCount > 2)
        {
            coinsInDeathPanel[0].color = new Vector4(255, 255, 255, 255);
            coinsInDeathPanel[1].color = new Vector4(255, 255, 255, 255);
            coinsInDeathPanel[2].color = new Vector4(255, 255, 255, 255);

        }
        else if (CoinCount > 1)
        {
            coinsInDeathPanel[1].color = new Vector4(255, 255, 255, 255);
            coinsInDeathPanel[0].color = new Vector4(255, 255, 255, 255);


        }
        else if (CoinCount > 0)
        {

            coinsInDeathPanel[0].color = new Vector4(255, 255, 255, 255);
        }


    }

    public void timeLimit()
    {
        if ((Time.time - currentTime) < timeMax)
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
