using UnityEngine;
using System.Collections;

public class EscapeScene : MonoBehaviour {

    [SerializeField]
    private string PrevScene;
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Fading.GetInstance().Finish(PrevScene);
        }
	}
}
