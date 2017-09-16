using UnityEngine;
using System.Collections;

public class AchievementScript : MonoBehaviour {

    public int totalKill;
    public int totalTuyulKilled = 0;
    public int totalLeakKilled = 0;
    public int totalPocongKilled = 0;
    public int totalBeguGanjangKilled = 0;
    public int totalKuntilAnakKilled = 0;

    private Status playerStatus;
    private int totalKillAchieved;
    private bool totalTuyulKilledAchieved = false;
    private bool totalLeakKilledAchieved = false;
    public bool totalPocongKilledAchieved = false;
    private bool totalBeguGanjangKillAchieved = false;
    public bool totalKuntilAnakKilledAchieved = false;

	// Use this for initialization
	void Start () {
        totalKill = 0;
        totalKillAchieved = 0;
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(totalKill);

        if (totalKillAchieved < 3)
        {
            if (totalKill >= 60 && totalKillAchieved <= 2)
            {
                playerStatus.attack += 150;
                playerStatus.armor += 70;
                totalKillAchieved++;
            }
            else if (totalKill >= 40 && totalKillAchieved <= 1)
            {
                playerStatus.attack += 90;
                playerStatus.armor += 40;
                totalKillAchieved++;
            }
            else if (totalKill >= 20 && totalKillAchieved <= 0)
            {
                Debug.Log("Yeay Total Kill 20");

                playerStatus.attack += 40;
                playerStatus.armor += 15;
                totalKillAchieved++;
            }
        }

        if(!totalTuyulKilledAchieved)
        {
            if (totalTuyulKilled >= 20)
            {
                Debug.Log("Total Tuyul Kill Achieved");
                playerStatus.speed += 2;
                totalTuyulKilledAchieved = true;
            }
        }

        if (!totalBeguGanjangKillAchieved)
        {
            if (totalBeguGanjangKilled >= 20)
            {
                Debug.Log("Total Begu Ganjang Kill Achieved");
                playerStatus.hp += 500f;
                playerStatus.attack += 100;
                totalTuyulKilledAchieved = true;
            }
        }

        if(!totalKuntilAnakKilledAchieved)
        {
            if (totalKuntilAnakKilled >= 20)
            {
                Debug.Log("Total Kuntil Anak Kill Achieved");
                playerStatus.hp += 100;
                totalKuntilAnakKilledAchieved = true;
            }
        }

        if(!totalLeakKilledAchieved)
        {
            if (totalLeakKilled >= 20)
                totalLeakKilledAchieved = true;
        }

        if(!totalPocongKilledAchieved)
        {
            if (totalPocongKilled >= 20)
                totalPocongKilledAchieved = true;
        }
    }
}
