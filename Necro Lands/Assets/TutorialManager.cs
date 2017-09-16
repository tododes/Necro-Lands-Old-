using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour {

    public string next;
    public int CurrentStateIndex;
    public Image transparent;
    public Fading Fade;

    private bool TutorialFinished = false;

    public List<Canvas> tutorCanvas = new List<Canvas>();
    public List<GameObject> tutorObjects = new List<GameObject>();
	// Use this for initialization
	void Awake () 
    {
        CurrentStateIndex = 0;
        for (int i = 0; i < 8; i++)
        {
            tutorObjects.Add(GameObject.Find("Tutorial Image Background " + i));
            tutorObjects[i].SetActive(false);
        }

        for (int i = 1; i <= 5; i++)
        {
            tutorCanvas.Add(GameObject.Find("Canvas "+i).GetComponent<Canvas>());
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            CurrentStateIndex++;
            Reset();
        }
        if (CurrentStateIndex <= 7)
            tutorObjects[CurrentStateIndex].SetActive(true);

        else if (CurrentStateIndex > 7)
        {
            if(!TutorialFinished)
            {
                Fade.Finish(next);
                TutorialFinished = true;
            }
            
            for (int i = 0; i < tutorObjects.Count; i++)
            {
                tutorObjects[i].SetActive(false);
            }

            
        }

        if (CurrentStateIndex >= 3 && !tutorCanvas[CurrentStateIndex - 3].enabled)
        {
            tutorCanvas[CurrentStateIndex - 3].enabled = true;
        }
	}

    void Reset()
    {
        for (int i = 0; i <= tutorObjects.Count; i++)
        {
            //if (tutorObjects[i].activeInHierarchy)
                tutorObjects[i].SetActive(false);
        }
        for (int i = 0; i <= tutorCanvas.Count; i++)
        {
           // if (tutorCanvas[i].enabled)
                tutorCanvas[i].enabled = false;
        }
    }
}
