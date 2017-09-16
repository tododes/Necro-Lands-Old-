using UnityEngine;
using System.Collections;

public class ItemExp : MonoBehaviour {

    [SerializeField]
    private string name;

    [SerializeField]
    private int Level, Exp, MaxExp;

    void Start()
    {
        Level = PlayerPrefs.GetInt(name + " Level");
        Exp = PlayerPrefs.GetInt(name + " Exp");
        MaxExp = PlayerPrefs.GetInt(name + " Max Exp");
    }
    
}
