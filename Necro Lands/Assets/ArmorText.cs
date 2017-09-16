using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmorText : MonoBehaviour {

    private Text text;
    private Player player;

    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text != "ARMOR\t\t" + player.Armor)
            text.text = "ARMOR\t\t" + player.Armor;
    }
}
