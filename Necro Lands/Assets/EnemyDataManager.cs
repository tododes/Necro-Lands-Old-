using UnityEngine;
using System.Collections;

public class EnemyDataManager : MonoBehaviour {
    public static int index;
    public GameObject[] player;
    public Sprite[] spr;
    private GameObject enemyDetail;
    private GameObject enemyExtras;
	// Use this for initialization
	void Start () {
        index = 0;
        enemyDetail = GameObject.Find("EnemyDetail");
        enemyExtras = GameObject.Find("GhostExtras");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyExtras.transform.position.y < 40f)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (i == index)
                {
                    player[i].transform.position = new Vector3(player[i].transform.position.x, 0f, player[i].transform.position.z);
                }
                else
                {
                    player[i].transform.position = new Vector3(player[i].transform.position.x, 20f, player[i].transform.position.z);
                }
            }
        }
        
        enemyDetail.GetComponent<SpriteRenderer>().sprite = spr[index];
	}
}
