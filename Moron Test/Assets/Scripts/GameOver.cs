using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Scenes scene;
    public GameObject gameover;
    // Use this for initialization
    void Start () {
        scene = FindObjectOfType<Scenes>();
    }
	


    public void Startover()
    {
        SceneManager.LoadScene("play");
        //scene.count_scenes = 0;
        //gameover.SetActive(false);
        //scene.Scenes_now[0].SetActive(true);
        //scene.Scenes_now[0].GetComponent<COntrolScene>().ReTry();

    }
    public void Retry()
    {

        gameover.SetActive(false); 
        scene.Scenes_now[scene.count_scenes].SetActive(true);
        try
        {
            scene.Scenes_now[scene.count_scenes].GetComponent<COntrolScene>().ReTry();
            try { scene.Scenes_now[scene.count_scenes].GetComponent<Scene17>().retry(); } catch { };
        }
        catch { try { scene.Scenes_now[scene.count_scenes].GetComponent<Scene17>().retry(); } catch { }; };
      
        //PlayerPrefs.SetInt("scene", scene.count_scenes);
        //PlayerPrefs.SetFloat("time", scene.counttime);
        //SceneManager.LoadScene("play");

    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Tap()
    {
        PlayerPrefs.SetInt("tap", 1);
        PlayerPrefs.Save();
        gameover.SetActive(false);
        scene.Scenes_now[scene.count_scenes].SetActive(true);
        try
        {
            scene.Scenes_now[scene.count_scenes].GetComponent<COntrolScene>().ReTry();
        }
        catch { try { scene.Scenes_now[scene.count_scenes].GetComponent<Scene17>().retry(); } catch { }; };
        

        //PlayerPrefs.SetInt("scene", scene.count_scenes);
        //PlayerPrefs.SetFloat("time", scene.counttime);
        // SceneManager.LoadScene("play");
    }
 
}
