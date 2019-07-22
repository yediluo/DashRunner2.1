using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretEntry : MonoBehaviour
{
    public int count;
    
    void Update() {
        if(count<0) {
            SceneManager.LoadScene("LevelS");

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            count--;
        
        }

    }
    
}
