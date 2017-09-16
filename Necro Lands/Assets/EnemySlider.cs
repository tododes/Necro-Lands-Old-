using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySlider : MonoBehaviour {

    private Enemy myStat;
    private Slider mySlider;
	// Use this for initialization
	void Start () 
    {
        myStat = transform.parent.parent.parent.gameObject.GetComponent<Enemy>();
        mySlider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (mySlider.maxValue != myStat.MaxHP)
            mySlider.maxValue = myStat.MaxHP;
        if (mySlider.value != myStat.HP)
            mySlider.value = myStat.HP;
        /*transform.LookAt(Camera.main.transform.position);
        transform.Rotate(new Vector3(0,180,0));*/
	}
}
