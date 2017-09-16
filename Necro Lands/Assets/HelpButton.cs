using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

    public int i;
   
	// Use this for initialization
	void Start ()
    {
        GameObject.Find("WeaponExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 0.8f, GameObject.Find("WeaponExtras").transform.position.z);
        GameObject.Find("GhostExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 40f, GameObject.Find("WeaponExtras").transform.position.z);
      
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x+0.03f, transform.localScale.y+0.03f, transform.localScale.z);

    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.03f, transform.localScale.y - 0.03f, transform.localScale.z);
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (i == 1)
        {
            /*HelpManager.WeaponData = true;
            HelpManager.GhostData = false;
            HelpManager.AboutData = false;*/
            GameObject.Find("WeaponExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 0.8f, GameObject.Find("WeaponExtras").transform.position.z);
            GameObject.Find("GhostExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 40f, GameObject.Find("WeaponExtras").transform.position.z);
            //GameObject.Find("WeaponExtras").transform.localScale = new Vector3(GameObject.Find("WeaponExtras").transform.localScale.x + 0.1f, GameObject.Find("WeaponExtras").transform.localScale.y + 0.1f, GameObject.Find("WeaponExtras").transform.localScale.z);
           
        }
        else if (i == 2)
        {
            /*HelpManager.WeaponData = false;
            HelpManager.GhostData = true;
            HelpManager.AboutData = false;*/
            GameObject.Find("WeaponExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 40f, GameObject.Find("WeaponExtras").transform.position.z);
            GameObject.Find("GhostExtras").transform.position = new Vector3(GameObject.Find("WeaponExtras").transform.position.x, 0.8f, GameObject.Find("WeaponExtras").transform.position.z);
            //GameObject.Find("GhostExtras").transform.localScale = new Vector3(GameObject.Find("GhostExtras").transform.localScale.x + 0.1f, GameObject.Find("GhostExtras").transform.localScale.y + 0.1f, GameObject.Find("GhostExtras").transform.localScale.z);
          
        }
        else
        {
            /*HelpManager.WeaponData = false;
            HelpManager.GhostData = false;
            HelpManager.AboutData = true;*/
        }
    }
}
