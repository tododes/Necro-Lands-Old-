using UnityEngine;
using System.Collections;

public class PlayerCanvas : MonoBehaviour {

    public GameManager manager;
    private Canvas myCanvas;
    private Player OurPlayer;
	// Use this for initialization
	void Start () 
    {
        myCanvas = GetComponent<Canvas>();
        OurPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log(OurPlayer.HP > 0 && GameManager.kills < manager.totalKillsRequired && !GameManager.Win && !GameManager.Lose);
        //if (myCanvas.enabled != (OurPlayer.HP > 0 && GameManager.kills < manager.totalKillsRequired && !GameManager.Win && !GameManager.Lose))
        gameObject.SetActive((OurPlayer.HP > 0 && GameManager.kills < manager.totalKillsRequired && !GameManager.Win && !GameManager.Lose));
        //myCanvas.enabled = (OurPlayer.HP > 0 && GameManager.kills < manager.totalKillsRequired && !GameManager.Win && !GameManager.Lose);
            //Debug.Log(myCanvas.enabled);
	}
}
