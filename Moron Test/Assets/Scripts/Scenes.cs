using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenes : MonoBehaviour {

    public GameObject[] Scenes_now;
    public int count_scenes = 0;
    public AudioSource audio_sound;
    public GameObject counttime_text;
    public float counttime;
    public float time_wait, add;
    public GameObject tap;
    public bool retry = false;
    public enum SceneName { play, play1,play2,play3 }
    public SceneName sceneName = SceneName.play;
    public bool stoptime = false;
    private void Start()
    {
        PlayerPrefs.DeleteKey("tap");

        counttime_text.SetActive(true);
        if (PlayerPrefs.HasKey("sound"))
        {
            if (PlayerPrefs.GetInt("sound") == -1)
            {
                audio_sound.Play();
            }
            else
            {
                audio_sound.Stop();
            }
        }
       // count_scenes = 0;
        Scenes_now[count_scenes].SetActive(true);
        StartCount();
    }
   
    void StartCount()
    {
        StartCoroutine(Starttime());
    }
    IEnumerator Starttime()
    {
        while (!stoptime)
        {
            yield return new WaitForSeconds(time_wait);
            counttime += add;
            counttime = (float)System.Math.Round(counttime, 1);
            counttime_text.GetComponent<Text>().text = counttime + "";
        }
     
    }

}
