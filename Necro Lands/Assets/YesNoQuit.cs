using UnityEngine;
using System.Collections;
using Todo;

public class YesNoQuit : MonoBehaviour {
    public choice c;
    public enum choice {Yes,No}
    GameObject[] s;
    GameObject t;


    void Start()
    {
        t = GameObject.Find("transparent");
        s = GameObject.FindGameObjectsWithTag("strategy");
        t.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < s.Length; i++)
        {
            s[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (!GameObject.Find("transparent").GetComponent<SpriteRenderer>().enabled)
        {
            Action.SetY(gameObject.name, -20f);
        }
        else
        {
            Action.SetY(gameObject.name, 0.61f);
        }
    }

    void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.07f, transform.localScale.y + 0.07f, transform.localScale.z);
    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.07f, transform.localScale.y - 0.07f, transform.localScale.z);
    }

    void OnMouseDown()
    {
        GameObject.Find("stone").GetComponent<AudioSource>().Play();
        if (c == choice.Yes)
            Application.Quit();
        else if (c == choice.No)
        {
            t.GetComponent<SpriteRenderer>().enabled = false;
            for (int i = 0; i < s.Length; i++)
            {
                s[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
