using UnityEngine;
using System.Collections;

public class GetBack : MonoBehaviour {

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("Extra");
    }

    void OnMouseOver()
    {
        if(gameObject.GetComponent<SpriteRenderer>() != null)
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, 0.17f);
    }

    void OnMouseExit()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = Color.white;
    }
}
