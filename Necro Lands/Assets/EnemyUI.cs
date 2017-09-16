using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyUI : MonoBehaviour {

	private EnemyStatus myStatus;
	private Slider HP;
	// Use this for initialization
	void Start () {
		HP = GetComponentInChildren<Slider> ();
		myStatus = GetComponentInParent<EnemyStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		HP.maxValue = myStatus.maxhp;
		HP.value = myStatus.hp;
		this.transform.LookAt (Camera.main.transform.position);
		this.transform.Rotate (new Vector3(0,180,0));
	}
}
