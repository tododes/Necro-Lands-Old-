using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewardExpText : MonoBehaviour {
    private Text myText;
    private DailyReward rewards;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        rewards = GetComponentInParent<DailyReward>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        myText.text = "+ " + rewards.reward.exp;
	
	}
}
