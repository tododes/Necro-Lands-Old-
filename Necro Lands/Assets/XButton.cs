using UnityEngine;
using System.Collections;

public class XButton : MonoBehaviour {

    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
