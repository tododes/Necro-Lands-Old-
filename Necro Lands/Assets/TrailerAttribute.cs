using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrailerAttribute : MonoBehaviour {

    public float hp = 0, attack = 0, armor = 0, speed = 0, SR = 0;
    public float maxhp, maxAttack, maxArmor, maxSpeed, maxSR;
    public Slider hpSlider, atkSlider, armorSlider, speedSlider, SRSlider;
    public GameObject[] fill;
    public Color color;

    public static bool finishedSliding = false;
	// Use this for initialization
	void Start () {
        hpSlider.maxValue = 5;
        atkSlider.maxValue = 5;
        armorSlider.maxValue = 5;
        speedSlider.maxValue = 5;
        SRSlider.maxValue = 5;
        fill = GameObject.FindGameObjectsWithTag("Fill");
        for (int i = 0; i < fill.Length; i++)
        {
            fill[i].GetComponent<Image>().color = color;
        }


    }

    // Update is called once per frame
    void Update() {
        if (TextTranslate.isReady)
        {
            if (hp < maxhp)
            {
                hp += 2.2f * Time.deltaTime;
            }

            if (attack < maxAttack)
            {
                attack += 2.2f * Time.deltaTime;
            }

            if (armor < maxArmor)
            {
                armor += 2.2f * Time.deltaTime;
            }

            if (speed < maxSpeed)
            {
                speed += 2.2f * Time.deltaTime;
            }

            if (SR < maxSR)
            {
                SR += 2.2f * Time.deltaTime;
            }
            hpSlider.value = hp;
            atkSlider.value = attack;
            armorSlider.value = armor;
            speedSlider.value = speed;
            SRSlider.value = SR;
        }
     
    }
}
