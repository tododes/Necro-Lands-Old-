using UnityEngine;
using System.Collections;

public class EnemyDataLR : MonoBehaviour {

    public string dir;
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (dir.ToLower() == "l")
        {
            EnemyDataManager.index--;
            if (EnemyDataManager.index < 0)
                EnemyDataManager.index = 4;
        }
        if (dir.ToLower() == "r")
        {
            EnemyDataManager.index++;
            if (EnemyDataManager.index > 4)
                EnemyDataManager.index = 0;
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
