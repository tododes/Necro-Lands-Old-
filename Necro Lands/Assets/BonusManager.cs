using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {

    float timer;
    public static bool instakillEnabled, doubledamageEnabled, doublespeedEnabled, InvulEnabled;
    float BuffTimer;

    void Start()
    {
        timer = 0;
        InvokeRepeating("DetermineBonus",60f, 60f);
        BuffTimer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (BuffTimer > 0f)
        {
            BuffTimer -= Time.deltaTime;
        }
        else
        {
            BuffTimer = 0f;
            if (instakillEnabled)
                instakillEnabled = false;
            if (doubledamageEnabled)
                doubledamageEnabled = false;
            if (doublespeedEnabled)
                doublespeedEnabled = false;
            if (InvulEnabled)
                InvulEnabled = false;
        }
    }

    void DetermineBonus()
    {
        if (timer > 59f)
        {
            int randomness = Random.Range(0, 100);
            if (randomness < 25)
            {
                //insta-kill
                instakillEnabled = true;
                
            }
            else if (randomness < 50)
            {
                //double damage
                
                doubledamageEnabled = true;
               
            }
            else if (randomness < 75)
            {
                //double speed
                
                doublespeedEnabled = true;
               
            }
            else
            {
                //invulnerable
                
                InvulEnabled = true;
            }
            BuffTimer = 20f;
        }
     
    }
}
