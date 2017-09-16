using UnityEngine;
using System.Collections;

public class HelpManager : MonoBehaviour {
    public static bool GhostData, WeaponData, AboutData;
    public bool isInHelpMenu;

    private GameObject HelpBorder;
    // Use this for initialization
    void Start ()
    {
        WeaponData = true;
        GhostData = false;
        AboutData = false;
        
        isInHelpMenu = false;
        HelpBorder = GameObject.Find("HelpBorder");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isInHelpMenu && HelpBorder.transform.position.x > 0f)
        {
            HelpBorder.transform.Translate(Vector3.left * 12f * Time.deltaTime);
        }
        else if (!isInHelpMenu && HelpBorder.transform.position.x < 15f)
        {
            HelpBorder.transform.Translate(Vector3.right * 12f * Time.deltaTime);
        }
    }
}
