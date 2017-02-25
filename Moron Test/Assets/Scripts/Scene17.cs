using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene17 : MonoBehaviour {

    public Scenes scene;
    public GameObject gameover;
    public float timenext;
    public bool stop = false;
    public AudioSource buzz;
    public AudioSource click;
    public float t = 0;
    public bool timedie = false;
    public bool timescene = false;
    // Use this for initialization
    void Start () {
        stop = false;
        scene = FindObjectOfType<Scenes>();
    }
	
    public void retry()
    {
        stop = false;
      
    }
	// Update is called once per frame
	void Update () {
        if (!timedie)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buzz.Play();
                scene.counttime_text.SetActive(false);
                gameObject.SetActive(false);
                gameover.SetActive(true);
                stop = true;
                t = 0;
                
            }
            t = Mathf.MoveTowards(t, timenext, Time.deltaTime);
            if (t >= timenext && !stop)
            {
                Next();
            }
        }else
        {
     
            if (Input.GetMouseButtonDown(0) && !timescene)
            {
                click.Play();
                Next();
                stop = true;           
            }

            t = Mathf.MoveTowards(t, timenext, Time.deltaTime);
            if (t >= timenext && !stop)
            {
                buzz.Play();
                scene.counttime_text.SetActive(false);
                gameObject.SetActive(false);
                gameover.SetActive(true);
                stop = true;
                t = 0;
            }
        }
      
	}

    void Next()
    {
        if (!stop)
        {
            gameObject.SetActive(false);
            scene.count_scenes++;
            if(gameObject.name == "scene_38")
            {
                scene.counttime_text.SetActive(false);
            }
            scene.Scenes_now[scene.count_scenes].SetActive(true);
            PlayerPrefs.SetFloat("time", scene.counttime);
        }
    }
    
}
