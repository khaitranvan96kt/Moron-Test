using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene28 : MonoBehaviour {

    public Scenes scene;
    public GameObject gameover;
    public float timenext;
    public GameObject keyobject;
    public AudioSource click;
    // Use this for initialization
    void Start()
    {
        scene = FindObjectOfType<Scenes>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == keyobject.name)
            {
                Next();
                click.Play();
            }
            else
            {
                gameObject.SetActive(false);
                gameover.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonDown(0) && !Physics.Raycast(ray, out hit))
        {
            gameObject.SetActive(false);
            gameover.SetActive(true);
        }
    }

    void Next()
    {        
            gameObject.SetActive(false);
            scene.count_scenes++;
            scene.Scenes_now[scene.count_scenes].SetActive(true);
        
    }
}
