using UnityEngine;
using System.Collections;

public class WeaponDataManager : MonoBehaviour {
    public static int WeaponIndex;
    public Sprite[] Weapon, WeaponDetails;
    private GameObject WeaponSprite, WeaponDetail;
	// Use this for initialization
	void Start ()
    {
        WeaponSprite = GameObject.Find("WeaponSprite");

        WeaponDetail = GameObject.Find("WeaponDetail");
        WeaponIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

        WeaponSprite.GetComponent<SpriteRenderer>().sprite = Weapon[WeaponIndex];
        WeaponDetail.GetComponent<SpriteRenderer>().sprite = WeaponDetails[WeaponIndex];
    }
}
