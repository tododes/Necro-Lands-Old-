using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyItemDrop : MonoBehaviour {

    [SerializeField]
    private TreasureChest chest;

    public void OnItemDrop(int c)
    {
        int r = Random.Range(0, 100);
        if(r < c)
        {
            Instantiate(chest, transform.position, chest.transform.rotation);
        }
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
