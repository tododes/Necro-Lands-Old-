using UnityEngine;
using System.Collections;

public class DisableHelpManager : MonoBehaviour {

    private HelpManager helpManager;
	// Use this for initialization
	void Start () {
        helpManager = GameObject.Find("HelpBorder").GetComponent<HelpManager>();
	}

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        helpManager.isInHelpMenu = false;
    }
}
