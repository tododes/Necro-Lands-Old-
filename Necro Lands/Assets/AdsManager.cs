using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour
{

    public static AdsManager singleton;

    [SerializeField]
    private GameObject warning;

    void Awake()
    {
        singleton = this;
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            warning.SetActive(true);
        }
    }
}
