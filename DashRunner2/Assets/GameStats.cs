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
    public int CoinCount;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
       sceneName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
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
}
