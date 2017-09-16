using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaSlider : MonoBehaviour {

    private Player player;
    private Slider me;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        me = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (me.maxValue != player.MaxMana)
            me.maxValue = player.MaxMana;
        if (me.value != player.Mana)
            me.value = player.Mana;
    }
}
