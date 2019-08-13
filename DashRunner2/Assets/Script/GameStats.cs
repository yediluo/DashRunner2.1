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
    [SerializeField]public  Image Battery;
    [SerializeField] Sprite[] batterySprites;
    [SerializeField] Button[] PauseResume;
     public float timeMax;





    //support

    PlayerTest player;
    public int CoinCount;
    public string sceneName;
    public float initTime;
    //whether player touched destinatation or not;
    public bool touchDown;
    // Start is called before the first frame update
    void Start()
    {
        touchDown = false;
        player = FindObjectOfType<PlayerTest>();
       sceneName = SceneManager.GetActiveScene().name;
        initTime = Time.time;
        timeMax = 35f;
    }



    // Update is called once per frame
    void Update()
    {

        timeLimit();
       // Debug.Log("coincount= " + CoinCount);
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

        //disable battery image and pause resume;
        Battery.enabled = false;
        PauseResume[0].interactable = false;
        PauseResume[1].interactable = false;

        PauseResume[2].interactable = false;
        PauseResume[3].interactable = false;
        PauseResume[3].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);  
        
        PauseResume[2].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);

        PauseResume[1].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        PauseResume[0].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);

        PauseResume[0].transform.position = new Vector2(1000,1000);


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

        //disable battery image and pause resume button;
        Battery.enabled = false;
        PauseResume[0].interactable = false;
        PauseResume[1].interactable = false;
        PauseResume[2].interactable = false;
        PauseResume[3].interactable = false;
        PauseResume[3].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);  
        PauseResume[2].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        PauseResume[1].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        PauseResume[0].GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        PauseResume[0].transform.position = new Vector2(1000,1000);

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
        if ((Time.time - initTime) < timeMax)
        {
            float timeRemaining = timeMax - (Time.time - initTime);
            float batteryPercentage = timeRemaining / timeMax;
           // Debug.Log("Time+ = " + (Time.time - initTime));
            
            //timeLeft.text = ("TimeLeft: = " + (Time.time - initTime));
            if(batteryPercentage > 11f/12f)
            {
                Battery.sprite = batterySprites[0];
            }else if(batteryPercentage > 11f / 12f)
            {
                Battery.sprite = batterySprites[0];

            }
            else if(batteryPercentage > 10f / 12f)
            {
                Battery.sprite = batterySprites[1];

            }
            else if (batteryPercentage > 9f / 12f)
            {
                Battery.sprite = batterySprites[2];

            }
            else if (batteryPercentage > 8f / 12f)
            {
                Battery.sprite = batterySprites[3];

            }
            else if (batteryPercentage > 7f / 12f)
            {
                Battery.sprite = batterySprites[4];

            }
            else if (batteryPercentage > 6f / 12f)
            {
                Battery.sprite = batterySprites[5];

            }
            else if (batteryPercentage > 5f / 12f)
            {
                Battery.sprite = batterySprites[6];

            }
            else if (batteryPercentage > 4f / 12f)
            {
                Battery.sprite = batterySprites[7];

            }
            else if (batteryPercentage > 3f / 12f)
            {
                Battery.sprite = batterySprites[8];

            }
            else if(batteryPercentage > 2f / 12f)
            {
                Battery.sprite = batterySprites[9];

            }
            else if(batteryPercentage > 1f / 12f)
            {
                Battery.sprite = batterySprites[10];

            }
            else {
                Battery.sprite = batterySprites[11];

            }


        } else
        {
            if (player.isAlive)
            {
               // timeLeft.text = ("TimeLeft: = " + (Time.time - initTime));

                player.deathMove();
            }
           
        }
    }
}
