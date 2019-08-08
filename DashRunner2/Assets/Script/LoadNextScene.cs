using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    SpriteRenderer mySR;
    GameStats gs;
    PlayerTest player;
    
    private void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        gs = FindObjectOfType<GameStats>();
        player = FindObjectOfType<PlayerTest>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mySR.enabled = false;
        //show win panel
        //        LoadScene();
        player.rb.bodyType = RigidbodyType2D.Static;
        gs.winPanel();
        gs.touchDown = true;

    }

    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().name=="Level10"||SceneManager.GetActiveScene().name=="LevelS")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    public void LoadExit()
    {
        SceneManager.LoadScene(0);

    }

    public void loadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");

    }
    public void loadLevel1()
    {
        SceneManager.LoadScene(3);
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene(4);
    }
    public void loadLevel3()
    {
        SceneManager.LoadScene(5);
    }
    public void loadLevel4()
    {
        SceneManager.LoadScene(6);
    }
    public void loadLevel5()
    {
        SceneManager.LoadScene(7);
    }
    public void loadLevel6()
    {
        SceneManager.LoadScene(8);
    }
    public void loadLevel7()
    {
        SceneManager.LoadScene(9);
    }
    public void loadLevel8()
    {
        SceneManager.LoadScene(10);
    }
    public void loadLevel9()
    {
        SceneManager.LoadScene(11);
    }

    public void loadLevel10()
    {
        SceneManager.LoadScene(12);
    }

    public void loadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
