using UnityEngine;
using System.Collections;

public class ExtraManager : MonoBehaviour {

    public bmenu b;
    public enum bmenu {ghost,weapon,story};
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (b == bmenu.ghost)
        {
            Application.LoadLevel("GhostExtra");
        }
        else if (b == bmenu.weapon)
        {
            Application.LoadLevel("WeaponExtra");
        }
        else if (b == bmenu.story)
        {
            Application.LoadLevel("HowToPlay");
        }
    }

    void OnMouseOver()
    {
        if(gameObject.name.Contains("stone"))
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, 0.17f);
    }

    void OnMouseExit()
    {
        if (gameObject.name.Contains("stone"))
            GetComponent<SpriteRenderer>().color = Color.white;
    }
}
