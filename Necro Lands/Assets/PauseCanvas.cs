using UnityEngine;
using System.Collections;

public class PauseCanvas : MonoBehaviour {

    private GameObject QuitConfirmation;

    void Awake()
    {
        QuitConfirmation = transform.Find("Quit Confirmation").gameObject;
        
    }

    public void EnableQuitConfirmation()
    {
        QuitConfirmation.SetActive(true);
    }

    public void DisableQuitConfirmation()
    {
        QuitConfirmation.SetActive(false);
    }
}
