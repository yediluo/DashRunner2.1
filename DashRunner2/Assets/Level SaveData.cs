using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class LevelSaveData {
    //SAVE DATA

    public int LevelReached;
    public float[] LevelInfo;


    public LevelSaveData(PlayerTest player,GameStats gs)
    {
        //currentLevel
        LevelInfo[0] = player.Level;
        LevelInfo[0] = gs.CoinCount;
    }
}
