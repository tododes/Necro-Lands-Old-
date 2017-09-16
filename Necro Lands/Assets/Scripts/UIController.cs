using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private Slider hpSlider;
    private Status playerStatus;
    private Text atkText, armorText;

    // Use this for initialization
    void Awake() {

        hpSlider = GameObject.FindGameObjectWithTag("HP Life").GetComponent<Slider>();
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
        atkText = GameObject.Find("Atk Text").GetComponent<Text>();
        armorText = GameObject.Find("Armor Text").GetComponent<Text>();
        SetAvatarPicture();
    }

    

    // Update is called once per frame
    void Update() {
        setMaxHp(playerStatus.maxhp);
        hpSlider.value = playerStatus.hp;
        DisplayAttribute();
        
        SetMoney();
        
        //Debug.Log(GameObject.Find("Buff1").GetComponent<Image>().enabled);
    }

    void SetMoney()
    {
        GameObject.Find("Money").GetComponent<Text>().text = ""+PlayerPrefs.GetInt("gold");
    }

    public void setMaxHp(float value)
    {
        hpSlider.maxValue = value;
    }

    public void TriggerAreYouSure()
    {
        GetComponent<AudioSource>().Play();
        GameObject.Find("AreYouSureCanvas").GetComponent<Canvas>().enabled = true;
    }

    void DisplayAttribute()
    {
        atkText.text = "" + playerStatus.attack;
        armorText.text = "" + playerStatus.armor;
    }



    void SetAvatarPicture()
    {
        GameObject.Find(PlayerPrefs.GetString("charname") + "Image").GetComponent<Image>().enabled = true;
        string[] n = { "Grant", "Trevor", "Marcia", "Lucy" };
        for (int i = 0; i < n.Length; i++)
        {
            if (n[i] != PlayerPrefs.GetString("charname"))
            {
                GameObject.Find(n[i] + "Image").GetComponent<Image>().enabled = false;
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = false;
    }

    public void quit()
    {
        GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("AreYouSureCanvas").GetComponent<Canvas>().enabled = true;
    }
}
