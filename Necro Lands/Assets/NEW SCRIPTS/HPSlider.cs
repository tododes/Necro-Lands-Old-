using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPSlider : MonoBehaviour {

    private Player player;
    private Slider me;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        me = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (me.maxValue != player.MaxHP)
            me.maxValue = player.MaxHP;
        if (me.value != player.HP)
            me.value = player.HP;
	}
}
