using UnityEngine;
using System.Collections;

public class YesNoDelete : MonoBehaviour {
    public choice c;
    public enum choice { Yes, No }

    void OnMouseDown()
    {
        GameObject.Find("stone").GetComponent<AudioSource>().Play();
        if (c == choice.Yes)
        {
            PlayerPrefs.DeleteAll();
            Application.LoadLevel("CharSelection");
        }
        else if (c == choice.No)
        {
            GameObject.Find("GO").GetComponent<Transform>().position = new Vector3(GameObject.Find("GO").GetComponent<Transform>().position.x, 10f, GameObject.Find("GO").GetComponent<Transform>().position.z);
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
}
