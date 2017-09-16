using UnityEngine;
using System.Collections;

public class WeaponDataLR : MonoBehaviour {

    public string dir;
  
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (dir.ToLower() == "l")
        {
            WeaponDataManager.WeaponIndex--;
            if (WeaponDataManager.WeaponIndex < 0)
                WeaponDataManager.WeaponIndex = 11;
        }
        if (dir.ToLower() == "r")
        {
            WeaponDataManager.WeaponIndex++;
            if (WeaponDataManager.WeaponIndex > 11)
                WeaponDataManager.WeaponIndex = 0;
        }
    }

    void OnMouseEnter()
    {
        if (transform.localScale.x > 0f)
            transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y + 0.1f, transform.localScale.z);
    }
    void OnMouseExit()
    {
        if (transform.localScale.x > 0f)
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y - 0.1f, transform.localScale.z);
    }
}
