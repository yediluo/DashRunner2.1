using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimePause : MonoBehaviour
{

	[SerializeField] Button [] PauseResume;
	PlayerTest player;
	Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
    	player = FindObjectOfType<PlayerTest>();
    	rb = player.GetComponent<Rigidbody2D>();
    	PauseResume[0].interactable = true;
    	PauseResume[1].interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseTime() {
    	PauseResume[0].interactable = false;
    	PauseResume[1].interactable = true;
    	//PauseResume[1].colors = new Vector4(255,255,255,255);


    	Time.timeScale = 0f;

    	//gs.Battery.enabled = false;
    	rb.bodyType = RigidbodyType2D.Static;

    	
    }


    public void resume() {
    	Time.timeScale = 1.0f;
		PauseResume[0].interactable = true;
    	PauseResume[1].interactable = false;
    	rb.bodyType = RigidbodyType2D.Dynamic;

    }
}
