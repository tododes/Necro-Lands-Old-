using UnityEngine;
using System.Collections;

public class DetectEnemy : MonoBehaviour {

    private PlayerAbilities playerAbilities;
    private PlayerInventories playerInventories;
    private string[] currInventories;

    private float timer;

	// Use this for initialization
	void Start () {
        playerAbilities = gameObject.transform.parent.GetComponent<PlayerAbilities>();
        playerInventories = gameObject.transform.parent.GetComponent<PlayerInventories>();
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
          
            if (PlayerPrefs.GetInt("Leakkill") == 2)
            {
                if (timer > 1f)
                {
                    timer = 0f;

                    other.gameObject.GetComponent<EnemyStatus>().hp -= 30f;
                }
            }
            for (int i = 0; i < currInventories.Length; i++)
            {
                if (currInventories[i].ToLower().CompareTo("hell sphere") == 0)
                {
                    
                    other.gameObject.GetComponent<EnemyStatus>().GotDamaged(20 * Time.deltaTime);
                    
                    break;
                }
            }


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (playerAbilities.getCurrPlayerName() == "Grant")
                playerAbilities.GrantAbility(other.gameObject);
            else if (playerAbilities.getCurrPlayerName() == "Lucy")
                playerAbilities.lucyAbility(other.gameObject);

            currInventories = playerInventories.currItems();

           
            if(PlayerPrefs.GetInt("Pocongkill") == 2)
            {
                other.gameObject.GetComponent<EnemyStatus>().armor -= 10f;
            }
           /* for (int i = 0; i < currInventories.Length; i++)
            {
               
                if (currInventories[i].ToLower().CompareTo("hell sphere") == 0)
                {
                    
                    other.gameObject.GetComponent<EnemyStatus>().GotDamaged(40 * Time.deltaTime);
                    break;
                }
            }*/

        }
    }

   
}
