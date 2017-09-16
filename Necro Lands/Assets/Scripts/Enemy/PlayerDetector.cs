using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

  

    private GameObject player;
    private EnemyAbilities enemyAbilities;
    private Transform parent;
    //private UIController uc;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAbilities = gameObject.transform.parent.GetComponent<EnemyAbilities>();
        parent = gameObject.transform.parent;
        //uc = GameObject.Find("Canvas").GetComponent<UIController>();
       
    }
	

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (parent.name.Contains("Leak"))
            {                
                enemyAbilities.LeakSkill(true);
                //Debug.Log("LEAK!!");
                other.gameObject.GetComponent<PlayerAbilities>().DisplayEffect(other.gameObject, "POISONED!!", Color.Lerp(Color.red, Color.blue,0.5f));
            }
            else if (parent.name.Contains("Pocong"))
            {
               
                enemyAbilities.PocongSkill(0.4f, 4f);
                other.gameObject.GetComponent<PlayerAbilities>().DisplayEffect(other.gameObject, "SLOWED!!\n-ARMOR", Color.gray);
            }
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            if (parent.name.Contains("Leak"))
            {
                enemyAbilities.LeakSkill(false);
               
            }
            else if(parent.name.Contains("Pocong"))
            {
                enemyAbilities.PocongSkill(0f, 0f);
              
            }
            
        }
    }

    void OnDestroy()
    {
        if (parent.name.Contains("Leak"))
        {
            enemyAbilities.LeakSkill(false);
           
        }
        else if (parent.name.Contains("Pocong"))
        {
            enemyAbilities.PocongSkill(0f, 0f);
           
        }
       
    }

}
