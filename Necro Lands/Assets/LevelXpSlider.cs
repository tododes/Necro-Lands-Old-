using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelXpSlider : MonoBehaviour {

    private Slider mySlider;
    private Player myPlayer;
    // Use this for initialization
    void Start()
    {
        mySlider = GetComponent<Slider>();
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mySlider.value != myPlayer.xp)
            mySlider.value = myPlayer.xp;
        if (mySlider.maxValue != 100 + 3 * myPlayer.level * myPlayer.level * myPlayer.level)
            mySlider.maxValue = 100 + 3 * myPlayer.level * myPlayer.level * myPlayer.level;
    }
}
