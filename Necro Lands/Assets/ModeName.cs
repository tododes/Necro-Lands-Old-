using UnityEngine;
using System.Collections;

public class ModeName : MonoBehaviour {

	public int index;
	private string[] name = {"ENDLESS MODE", "DEFENDING FRENZY","KILLING FRENZY","KUNTILANAK HUNT","POCONG HUNT","TUYUL HUNT","GENDERUWO HUNT","LEAK HUNT","BOSS FIGHT","MEGA BOSS FIGHT"};

	// Use this for initialization
	void Start () 
	{
		GetComponent<TextMesh> ().text = name [index];	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
