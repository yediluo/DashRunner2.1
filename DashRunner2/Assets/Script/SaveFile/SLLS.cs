using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLLS : MonoBehaviour
{
    public PlayerData data;
    [SerializeField] Button[] levelSButtons;
    [SerializeField] PlayerTest player;
    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            for (int i = 0; i < data.LevelInfos.Length; i++)
            {
                levelSButtons[i].GetComponentInChildren<Text>().text = data.LevelInfos[i].ToString();

            }
        }else
        {
            SaveSystem.SavePlayer(player);
            data = SaveSystem.LoadPlayer();
            for (int i = 0; i < data.LevelInfos.Length; i++)
            {
                levelSButtons[i].GetComponentInChildren<Text>().text = data.LevelInfos[i].ToString();

            }
        }

    }

}
