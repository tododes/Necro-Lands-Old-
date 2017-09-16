using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(beep());
	}

    IEnumerator beep()
    {
        while (true)
        {
            GetComponent<TextMesh>().text = "";
            yield return new WaitForSeconds(1);
            GetComponent<TextMesh>().text = "PRESS SPACE TO CONTINUE";
            yield return new WaitForSeconds(1);
            
        }
    }

    
}
