using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COntrolScene : MonoBehaviour {

    public bool except = false;
    public bool fixcollider= false;
    public GameObject []keyobject;
    public GameObject[] objectt;
    public Text question;
    public GameObject[] prekeyobject;
    public GameObject[] preobjectt;
    public string[] textquestion;
    public GameObject gameover;
    public int count_key = 0;
    public Scenes scene;
    public Sprite []breakegg;
    public float timenext;
    public AudioSource click;
    public AudioSource cashregister;
    public AudioSource buzz;
    public AudioSource[] audio;
    public bool stop = false;
    private bool tapp = false;
    public ArrayList saveobject = new ArrayList();

    // Use this for initialization
    void Start () {
        tapp = false;
        scene = FindObjectOfType<Scenes>();
        if (!fixcollider)
        {
            StartGame();
        }
       
    }

    public void StartGame()
    {
       
        
        GameObject u = null;
        if (keyobject.Length > 0)
        {
            u = keyobject[0];
        }
        for (int i = 0; i < keyobject.Length; i++)
        {
            

            if (i != 0 && u.name != keyobject[i].name)
            {
                keyobject[i].AddComponent<BoxCollider>();
                keyobject[i].GetComponent<BoxCollider>().size = new Vector3(keyobject[i].GetComponent<RectTransform>().rect.width, keyobject[i].GetComponent<RectTransform>().rect.height, 0);
            }
            if (i == 0)
            {
                keyobject[i].AddComponent<BoxCollider>();
                keyobject[i].GetComponent<BoxCollider>().size = new Vector3(keyobject[i].GetComponent<RectTransform>().rect.width, keyobject[i].GetComponent<RectTransform>().rect.height, 0);
            }


        }


    }

    public void ReTry()
    {
        if (PlayerPrefs.HasKey("tap"))
        {
            if (PlayerPrefs.GetInt("tap") == 1)
            {
                tapp = true;
                scene.tap.SetActive(true);
                scene.tap.transform.position = keyobject[0].transform.position;
                PlayerPrefs.SetInt("tap", -1);
                PlayerPrefs.Save();
            }
        }


        count_key = 0;
        stop = false;
        scene.counttime_text.SetActive(true);
        try
        {
            question.text = textquestion[0];
        }
        catch { };
        if (preobjectt.Length > 0)
        {
            for (int i = 0; i < preobjectt.Length; i++)
            {
                objectt[i].SetActive(preobjectt[i].activeSelf);
            }
        }

        if (prekeyobject.Length > 0)
        {
            for (int i = 0; i < prekeyobject.Length; i++)
            {

                keyobject[i].GetComponent<RectTransform>().localPosition = prekeyobject[i].GetComponent<RectTransform>().localPosition;
                keyobject[i].GetComponent<Image>().sprite = prekeyobject[i].GetComponent<Image>().sprite;
                keyobject[i].SetActive(prekeyobject[i].activeSelf);
            }
        }
       
          
      
        
    }
    // Update is called once per frame
    void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
   
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {   
            if(count_key>= keyobject.Length)
            {
                stop = true;
                GameOver();
            }
            else
            {
                if (hit.collider.gameObject.name == keyobject[count_key].name && !except )
                {

                    switch (scene.sceneName)
                    {
                        case Scenes.SceneName.play:
                            Funtion();
                            break;
                        case Scenes.SceneName.play1:
                            Funtion1();
                            break;
                        case Scenes.SceneName.play2:
                            Funtion1();
                            break;
                        case Scenes.SceneName.play3:
                            Funtion1();
                            break;
                    }
                    count_key++;
                    if (tapp && count_key < keyobject.Length)
                    {
                        scene.tap.transform.position = keyobject[count_key].transform.position;
                    }
                   
                }
                else if (except)
                {
                   
                    switch (scene.sceneName)
                    {
                        case Scenes.SceneName.play:
                            Funtion();
                            break;
                        case Scenes.SceneName.play1:
                            Funtion1();
                            break;
                        case Scenes.SceneName.play2:
                            Funtion1();
                            break;
                        case Scenes.SceneName.play3:
                            Funtion1();
                            break;

                    }                   
                    count_key++;
                    if (tapp && count_key < keyobject.Length)
                    {
                        scene.tap.transform.position = keyobject[count_key].transform.position;
                    }
                }
                else
                {
                    GameOver();
                }
            }      
           
        }
        else if(Input.GetMouseButtonDown(0) && !Physics.Raycast(ray, out hit) )
        {
            GameOver();
        }
       
	}
    void Funtion()
    {
        switch (scene.count_scenes+1)
        {
            case 1:
                click.Play();
                NextScene();
                break;
            case 2:
                if (count_key == 0)
                {
                    click.Play();
                    keyobject[0].SetActive(false);
                    question.text = textquestion[1];
                }
                else if(count_key == 1)
                {
                    click.Play();
                    keyobject[1].SetActive(false);
                    question.text = textquestion[2];
                }
                else
                {
                    click.Play();
                   keyobject[2].SetActive(false);
                    NextScene();
                }
                break;
            case 3:
                click.Play();
                NextScene();
                break;
            case 4:
                AudioSource egg = gameObject.GetComponent<AudioSource>();
                egg.Play();
                if (count_key <= 3)
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                }
                else
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                    NextScene();
                    break;
                }
                break;
            case 5:
                if (count_key == 0)
                {
                    click.Play();                 
                }
                else if (count_key == 1)
                {
                    click.Play();                  
                }
                else
                {
                    click.Play();
                    NextScene();
                }
                break;
            case 6:
                AudioSource duck = gameObject.GetComponent<AudioSource>();
                duck.Play();
                cashregister.Play();
                NextScene();
                break;
            case 7:
                click.Play();
                NextScene();
                break;
            case 8:
                if (count_key == 0)
                {
                    click.Play();
                    question.text = textquestion[1];
                    keyobject[0].GetComponent<RectTransform>().localPosition = (new Vector3(50, -67,0));
                    keyobject[1].GetComponent<RectTransform>().localPosition = (new Vector3(321, -174, 0));//= new Vector2(-468,-174);
                    keyobject[3].GetComponent<RectTransform>().localPosition = (new Vector3(-455, -174, 0));//= new Vector2(50,-67);
                }
                else if(count_key != 0 && count_key <= 2)
                {
                    click.Play();
                }
                else if(count_key ==3)
                {
                    click.Play();
                    NextScene();
                }

                    break;
            case 9:
                click.Play();
                NextScene();
                break;
            case 10:
                AudioSource duckk = gameObject.GetComponent<AudioSource>();
                duckk.Play();
                question.text = textquestion[1];
                if (count_key <= 3)
                {
                    keyobject[count_key].SetActive(false);
                }
                    if (count_key == 4)
                {
                    NextScene();
                }
                break;
            case 11:

                click.Play();
                if (count_key == 0)
                {
                    keyobject[count_key].SetActive(false);
                    objectt[1].SetActive(true);          
                    scene.tap.SetActive(false);
                    setAC11(objectt[1]);
                   
                }
                else if(count_key == 1)
                {
                    NextScene();
                }
                break;
            case 12:
                click.Play();
                NextScene();
                break;
            case 13:
                if (count_key <= 3)
                {
                    click.Play();
                    question.text = textquestion[1];
                }
                else
                {
                    click.Play();
                    NextScene();
                }
                break;
            case 14:
                click.Play();
                NextScene();
                break;
            case 15:
                AudioSource eggg = gameObject.GetComponent<AudioSource>();
                eggg.Play();
                if (count_key <= 1)
                {
                    question.text = textquestion[1];
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                }
                else
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                    NextScene();
                    break;
                }
                break;
            case 16:
                AudioSource duck_16 = gameObject.GetComponent<AudioSource>();
                duck_16.Play();
                //Animator ani16 = gameObject.GetComponent<Animator>();
                if (count_key <= 2)
                {
                    question.text = textquestion[1];
                    keyobject[count_key].SetActive(false);
                    //ani16.SetTrigger("run");
                }
                else
                {
                    NextScene();
                }
                break;
            case 18:
                click.Play();
                NextScene();
                break;
            case 19:
                if (count_key <= 9)
                {
                    click.Play();
                    question.text = textquestion[2];
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[count_key];
                }
                else if(count_key==10)
                {
                    AudioSource egg_19 = gameObject.GetComponent<AudioSource>();
                    egg_19.Play();
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[count_key];
                    stop = true;
                    setAC19(objectt[0]);
 
                }
                else
                {
                    stop = false;
                    audio[0].Play();
                    NextScene();
                }              
                break;
            case 21:
                click.Play();
                question.text = textquestion[1];
                if (count_key <= 5)
                {
                    if (count_key == 2)
                    {
                        keyobject[0].GetComponent<RectTransform>().localPosition = new Vector3(-400, -221, 0);
                    }
                }
                else
                {
                    NextScene();

                }
                break;
            case 22:
                click.Play();
                NextScene();
                break;
            case 23:
                click.Play();
                if (count_key<= 3)
                {
                    question.text = textquestion[1];
                    objectt[count_key].SetActive(false);
                    objectt[count_key+1].SetActive(true);
                }
                else
                {
                    NextScene();
                }
                break;
            case 25:
                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                }
                if (count_key == 2)
                {
                    NextScene();
                }
                break;
            case 27:
                click.Play();
                NextScene();
                break;
            case 29:
                click.Play();
                NextScene();
                break;
            case 30:
                click.Play();
                NextScene();
                break;
            case 31:
                click.Play();
                question.text = textquestion[1];
                if (count_key == 2)
                {
                    keyobject[0].GetComponent<RectTransform>().localPosition = new Vector3(369, -161, 0);
                }
                if(count_key == 5)
                {
                    keyobject[0].GetComponent<Image>().sprite = breakegg[0];
                    setAC31();
                }
                if (count_key > 5)
                {
                    if (stop)
                    {
                        GameOver();
                    }
                    else
                    {
                        if(count_key == 9)
                        {
                            NextScene();
                        }
                    }
                }
                break;
            case 32:
                click.Play();
                keyobject[0].GetComponent<Image>().sprite = breakegg[0];
                gameObject.GetComponent<Scene17>().stop = true;
                NextScene();                    
                break;
            case 33:
                click.Play();
                NextScene();
                break;
            case 34:
                click.Play();
                NextScene();
                break;
            case 36:
                click.Play();
                if (count_key <= 8)
                {                  
                    keyobject[count_key].SetActive(false);
                }
                else
                {
                    keyobject[count_key].SetActive(false);
                    NextScene();
                }
                break;
        }
       
    }

    void Funtion1()
    {
        switch (scene.count_scenes + 1)
        {
            case 1:
                click.Play();
                NextScene();
                break;
            case 2:
                click.Play();
                NextScene();
                break;
            case 3:
                click.Play();
                NextScene();
                break;
            case 4:
                click.Play();
                question.text = textquestion[1];
                if (count_key <= 1)
                {
                    keyobject[count_key].SetActive(false);
                }
                else
                {
                    NextScene();
                }
              
                break;
            case 5:
                click.Play();
                NextScene();
                break;
            case 6:
                click.Play();
                NextScene();
                break;
            case 7:
                click.Play();
                NextScene();
                break;
            case 8:
                click.Play();
                NextScene();
                break;
            case 9:
                click.Play();
                NextScene();
                break;
            case 10:
                
                question.text = textquestion[1];
                if (count_key <= 1)
                {
                    click.Play();
                    keyobject[count_key].SetActive(false);
                }
                else
                {
                    audio[1].Play();
                    NextScene();
                }

                break;
            case 11:
                click.Play();
                NextScene();
                break;
            case 12:
                click.Play();
                NextScene();
                break;
            case 13:
                click.Play();
                objectt[0].SetActive(false);
                objectt[1].SetActive(true);
                NextScene();
                break;
            case 14:
                click.Play();
                question.text = textquestion[1];
                if (count_key == 6)
                {
                    NextScene();
                }           
                break;
            case 15:
                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                    setAC11(objectt[1]);
                }   
                if (count_key == 1)
                {
                    nextScene();
                }
                break;
            case 17:
                click.Play();
                NextScene();
                break;
            case 18:
                click.Play();
                NextScene();
                break;
            case 19:
                click.Play();
                NextScene();
                break;
            case 20:
                click.Play();
                NextScene();
                break;
            case 21:
                click.Play();
                if (count_key == 2)
                {
                    keyobject[0].GetComponent<RectTransform>().localPosition = new Vector3(-316, -152, 0);
                }
                if(count_key == 4)
                {
                    keyobject[0].GetComponent<RectTransform>().localPosition = new Vector3(33, 40, 0);
                }
                if(count_key == 6)
                {
                    NextScene();
                }
             
                break;
            case 22:
                click.Play();
                NextScene();
                break;
            case 23:
                click.Play();
                question.text = textquestion[1];
                if (count_key <= 2)
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                }
                else
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                    NextScene();
                }
                break;
            case 24:
                click.Play();
                NextScene();
                break;
            case 25:

                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                    setAC11(objectt[1]);
                }
                if (count_key == 1)
                {
                    nextScene();
                }
                break;
            case 27:
                click.Play();
                NextScene();
                break;
            case 28:
                click.Play();
                NextScene();
                break;
            case 29:
                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                }
                else if (count_key == 1)
                {
                    objectt[1].SetActive(false);
                    objectt[2].SetActive(true);
                }
                else if (count_key == 2)
                {
                    objectt[2].SetActive(false);
                    objectt[3].SetActive(true);
                }
                else
                {
                    if(gameObject.GetComponent<Scene17>().stop== false)
                    {
                        nextScene();
                    }
                    else
                    {
                        GameOver();
                    }
                   
                }
                break;
            case 30:
                click.Play();
                if (count_key <= 2)
                {
                    keyobject[count_key].SetActive(false);
                    question.text = textquestion[1];
                }
                else
                {
                    NextScene();
                }
                break;
            case 31:
                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                    setAC11(objectt[1]);
                }
                if (count_key == 1)
                {
                    nextScene();
                }
                break;
            case 32:
                click.Play();
                if (count_key <= 3)
                {
                    objectt[count_key].SetActive(false);
                    objectt[count_key+1].SetActive(true);
                }
                else
                {
                    nextScene();
                }
                break;
            case 33:
                click.Play();
                NextScene();
                break;
            case 35:
                click.Play();
                NextScene();
                break;
            case 36:
                click.Play();
                NextScene();
                break;
            case 37:
                click.Play();
                keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                objectt[0].SetActive(false);
                NextScene();
                break;
            case 39:
                click.Play();
                question.text = textquestion[1];
                if (count_key == 6)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                }
                if (count_key == 7)
                {
                    objectt[0].SetActive(true);
                    objectt[1].SetActive(false);
                }
                if (count_key == 8)
                {
                    NextScene();
                }
                break;
            case 40:
                click.Play();
                NextScene();
                break;
            case 41:
                click.Play();
                NextScene();
                break;
            case 42:
                click.Play();
                if (count_key == 0)
                {
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                    setAC11(objectt[1]);
                }
                if (count_key == 1)
                {
                    nextScene();
                }
                break;
            case 44:
                click.Play();
                if (count_key == 0 || count_key ==4 || count_key == 8)
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[1];
                }
                if (count_key == 1 || count_key == 5 )
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[2];
                }
                if (count_key == 2 || count_key == 6 )
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[3];
                }
                if (count_key == 3 || count_key == 7 )
                {
                    keyobject[count_key].GetComponent<Image>().sprite = breakegg[0];
                }
                if (count_key == 10)
                {                 
                    objectt[0].SetActive(false);
                    objectt[1].SetActive(true);
                    stop = true;
                    setAC19(objectt[1]);

                }
                if(count_key == 11)
                {
                    stop = false;
                    nextScene();
                }
                break;
            case 46:
                scene.stoptime = true;
                scene.counttime_text.SetActive(false);
                click.Play();
                NextScene();
                break;
          
        }
    }

    void setAC31()
    {
        StartCoroutine(scene31());
    }
    IEnumerator scene31()
    {
        stop = true;
        yield return new WaitForSeconds(timenext);
        stop = false;
        keyobject[0].GetComponent<Image>().sprite = breakegg[1];
    }

    void setAC19(GameObject s)
    {
        StartCoroutine(sence19(s));
    }
    IEnumerator sence19(GameObject s)
    {
        scene.tap.SetActive(false);
        yield return new WaitForSeconds(timenext);
        s.SetActive(true);
        if (tapp)
        {
            scene.tap.SetActive(true);
        }     
        question.text = textquestion[1];
        yield return new WaitForSeconds(1f);
        if (stop)
        {
            GameOver();
        }
    }


    void NextScene()
    {
        scene.tap.SetActive(false);
        Invoke("nextScene", timenext);
    }
    
    void nextScene()
    {
        scene.tap.SetActive(false);
        if (!stop)
        {
            gameObject.SetActive(false);
            scene.count_scenes++;
            scene.Scenes_now[scene.count_scenes].SetActive(true);
            if(scene.sceneName == Scenes.SceneName.play)
            {
                PlayerPrefs.SetFloat("timePlay", scene.counttime);
            }
            else if(scene.sceneName == Scenes.SceneName.play1)
            {
                PlayerPrefs.SetFloat("timePlay1", scene.counttime);
            }
            
        }
    }


    void setAC11(GameObject s)   // scene 11
    {
        StartCoroutine(Next(s));
    }
    IEnumerator Next(GameObject s)
    {
        scene.tap.SetActive(false);
        yield return new WaitForSeconds(timenext);
        s.SetActive(false);
        if (tapp)
        {
            scene.tap.SetActive(true);
        }      
        objectt[2].SetActive(true);
    }

    void GameOver()
    {
        buzz.Play();
        stop = true;
        scene.tap.SetActive(false);
        tapp = false;
        scene.counttime_text.SetActive(false);
        gameObject.SetActive(false);
        gameover.SetActive(true);
    }
}

