using UnityEngine;
using System.Collections;

public class ExitUpgradeAttribute : MonoBehaviour {

	public void ExitUpgrade()
    {
        transform.parent.parent.GetComponent<Canvas>().enabled = false;
    }
}
