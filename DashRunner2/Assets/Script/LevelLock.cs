using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using System.Net;
using TMPro;

public class LevelLock : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerData data;
    public int totalCoinCollect;
    public Button worldPeachSelectB;
    public Image peachLockImage;
    public TextMeshProUGUI peachLockMessage;
    
    public TextMeshProUGUI CoinCountTest;
    public int peachWorldCoinLimit;

    private void Awake()
    {
        data = SaveSystem.LoadPlayer();

    }
    void Start()
    {

        for (int i = 0; i < data.LevelInfos.Length; i++)
        {
            totalCoinCollect += data.LevelInfos[i];

        }
        Debug.Log("coin collected:= " + totalCoinCollect);
        CoinCountTest.text = (totalCoinCollect.ToString());
        if (totalCoinCollect >= peachWorldCoinLimit)
        {
            Debug.Log("unlock peach" + totalCoinCollect);
            worldPeachSelectB.enabled = true;
            peachLockImage.enabled = false;
            peachLockMessage.enabled = false;


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        peachLockMessage.text = peachWorldCoinLimit.ToString() + " Coins to Unlock";

    }
}
