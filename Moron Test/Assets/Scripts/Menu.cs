using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Sprite mute;
    public Sprite onsound;
    public AudioSource audio_sound;
    public GameObject mysound;
    public GameObject[] level;
    [SerializeField]
    private Text text_oldschool;
    [SerializeField]
    private Text text_late;
    // Use this for initialization

    void Start () {
        PlayerPrefs.DeleteKey("sound");
        PlayerPrefs.DeleteKey("scene");
        if (PlayerPrefs.HasKey("timePlay"))
        {
            text_oldschool.text = "Best Time: "+ PlayerPrefs.GetFloat("timePlay")  + "s";
        }
        else
        {
            text_oldschool.text = "Play now";
        }
        if (PlayerPrefs.HasKey("timePlay1"))
        {
            text_late.text = "Best Time: " + PlayerPrefs.GetFloat("timePlay1") + "s";
        }
        else
        {
            text_late.text = "Play now";
        }
    }
	
	// Update is called once per frame


   public void oldschool()
    {
        SceneManager.LoadScene("play");
    }
    public void lateRegistrantion()
    {
        SceneManager.LoadScene("play1");
    }
    public void SoundChange()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            if(PlayerPrefs.GetInt("sound") == 1)
            {
                audio_sound.Play();
                PlayerPrefs.SetInt("sound", -1);
                PlayerPrefs.Save();
                mysound.GetComponent<Image>().sprite = onsound;
            }
            else
            {
                audio_sound.Stop();
                PlayerPrefs.SetInt("sound",1);
                PlayerPrefs.Save();
                mysound.GetComponent<Image>().sprite = mute;
            }
        }
        else
        {           
            audio_sound.Stop();
            mysound.GetComponent<Image>().sprite = mute;
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.Save();
        }
    }
}
