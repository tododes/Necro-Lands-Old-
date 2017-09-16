using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageImageClass : MonoBehaviour {

    private float x;

    void Start()
    {
        x = 0.85f;
    }
    void Update()
    {
        if (x >= 0 && GetComponent<Image>().enabled)
        {
            x -= 0.25f;
        }
        else if (x < 0)
        {
          
            if(GetComponent<Image>().enabled)
                GetComponent<Image>().enabled = false;
            x = 0.85f;
        }
        
        GetComponent<Image>().color = Color.Lerp(Color.clear, Color.red, x);
    }

    public void setX(float xx)
    {
        x = xx;
    }

    public float getX()
    {
        return x;
    }
}
