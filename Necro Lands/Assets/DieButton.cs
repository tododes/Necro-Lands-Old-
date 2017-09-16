using UnityEngine;
using System.Collections;
using Todo;

public class DieButton : MonoBehaviour {

    public void open()
    {
        Application.LoadLevel("Game Menu Scene");
    }
}
