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
        if (SceneManager.GetActiveScene().name=="Level30"||SceneManager.GetActiveScene().name=="LevelS")
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

    public void loadWorldSelect()
    {
        SceneManager.LoadScene("WorldSelect");

    }

    public void loadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");

    }

    public void loadLevelSelection2()
    {
        SceneManager.LoadScene("LevelSelect Peach");
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

    public void loadLevel11()
    {
        SceneManager.LoadScene(13);
    }

    public void loadLevel12()
    {
        SceneManager.LoadScene(14);
    }


    public void loadLevel13()
    {
        SceneManager.LoadScene(15);
    }

    public void loadLevel14()
    {
        SceneManager.LoadScene(16);
    }

    public void loadLevel15()
    {
        SceneManager.LoadScene(17);
    }

    public void loadLevel16()
    {
        SceneManager.LoadScene(18);
    }

    public void loadLevel17()
    {
        SceneManager.LoadScene(19);
    }


    public void loadLevel18()
    {
        SceneManager.LoadScene(20);
    }

    public void loadLevel19()
    {
        SceneManager.LoadScene(21);
    }

    public void loadLevel20()
    {
        SceneManager.LoadScene(22);
    }

    public void loadLevel21()
    {
        SceneManager.LoadScene(23);
    }

    public void loadLevel22()
    {
        SceneManager.LoadScene(24);
    }

    public void loadLevel23()
    {
        SceneManager.LoadScene(25);
    }

    public void loadLevel24()
    {
        SceneManager.LoadScene(26);
    }

    public void loadLevel25()
    {
        SceneManager.LoadScene(27);
    }

    public void loadLevel26()
    {
        SceneManager.LoadScene(28);
    }

    public void loadLevel27()
    {
        SceneManager.LoadScene(29);
    }

    public void loadLevel28()
    {
        SceneManager.LoadScene(30);
    }

    public void loadLevel29()
    {
        SceneManager.LoadScene(31);
    }

    public void loadLevel30()
    {
        SceneManager.LoadScene(32);
    }


    public void loadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
