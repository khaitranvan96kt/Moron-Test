using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public Scenes scene;
 
	// Use this for initialization
	void Start () {
        scene = FindObjectOfType<Scenes>();
        scene.counttime_text.SetActive(false);
        scene.stoptime = true;
        if (scene.sceneName == Scenes.SceneName.play)
        {
            PlayerPrefs.SetFloat("timePlay", scene.counttime);
        }
        else if (scene.sceneName == Scenes.SceneName.play1)
        {
            PlayerPrefs.SetFloat("timePlay1", scene.counttime);
        }
    }
	
	
}
