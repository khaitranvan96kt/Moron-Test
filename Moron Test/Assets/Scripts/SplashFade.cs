/*Developed and provided by SpeedTutor - www.speed-tutor.com*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SplashFade : MonoBehaviour
{
    public Image splashImage;
    public string loadLevel;
    public float timenext = 2;
    IEnumerator Start()
    {
        
        splashImage.canvasRenderer.SetAlpha(0.5f);
        FadeIn();
        yield return new WaitForSeconds(timenext);
        FadeOut();
        yield return new WaitForSeconds(timenext);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(0.9f, 2.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(1, 2.5f, false);
    }


}
