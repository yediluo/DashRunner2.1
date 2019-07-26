using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLLS : MonoBehaviour
{
    public PlayerData data;
    [SerializeField] Button[] levelSButtons;
    [SerializeField] PlayerTest player;
    [SerializeField] Sprite[] LevelLogo;

    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            for (int i = 0; i < data.LevelInfos.Length; i++)
            {
                levelSButtons[i].GetComponentInChildren<Text>().text = data.LevelInfos[i].ToString() + " " + data.CurrentLevel;

            }
        }
        else
        {
            SaveSystem.SavePlayer(player);
            data = SaveSystem.LoadPlayer();
            for (int i = 0; i < data.LevelInfos.Length; i++)
            {
                levelSButtons[i].GetComponentInChildren<Text>().text = data.LevelInfos[i].ToString()+" "+ data.CurrentLevel;

            }


        }

        //LevelLock;
        if (data.LevelInfos[0]>0)
        {
            for (int i = 0; i <= data.CurrentLevel; i++)
            {
                levelSButtons[i].image.sprite = LevelLogo[i];
                levelSButtons[i+1].image.sprite = LevelLogo[i+1];

                // levelSButtons[i].image.color = Color.black;
                levelSButtons[i].enabled = true;
                levelSButtons[i + 1].enabled = true;
            }
        }else
        {
            levelSButtons[0].image.sprite = LevelLogo[0];
            levelSButtons[0].enabled = true;
        }


    }

}
