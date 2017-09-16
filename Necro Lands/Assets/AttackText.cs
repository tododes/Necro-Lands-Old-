using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackText : MonoBehaviour {

    private Text text;
    private Player player;

	void Start () 
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (text.text != "ATTACK\t\t" + player.Attack)
            text.text = "ATTACK\t\t" + player.Attack;
	}
}
