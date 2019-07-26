﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class PlayerData {
    //SAVE DATA

    public int[] LevelInfos;
    public int CurrentLevel;


    public PlayerData(PlayerTest player)
    {
        LevelInfos = new int[6];
        
            for (int i = 0; i < LevelInfos.Length; i++)
            {
                LevelInfos[i] = player.MaxCoinCount[i];
            }
        CurrentLevel = player.maxLevel;
    }
}