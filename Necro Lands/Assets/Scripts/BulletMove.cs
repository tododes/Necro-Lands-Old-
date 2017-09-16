using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float speed = 20f;

    private GameObject player;
    private Vector3 shootDirection, shootDirectionLeft, shootDirectionRight;
    private Status playerStatus;
    private PlayerAbilities playerAbilities;
    private float bulletDamage;
    private PlayerInventories playerInventories;
    private string[] currInventories;
    private Transform playerRot;

    int floorMask;

    // Use this for initialization
    void Start () {
        floorMask = LayerMask.GetMask("Floor");
       
        shootDirection = player.transform.forward;
        playerStatus = player.GetComponent<Status>() ;
        playerAbilities = player.GetComponent<PlayerAbilities>();
        playerInventories = player.GetComponent<PlayerInventories>();
        shootDirectionLeft =  -1 * player.transform.right;
        shootDirectionRight = player.transform.right;
    }
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        if (gameObject.name.Contains("Left") || gameObject.name.Contains("L"))
        {

            transform.eulerAngles = new Vector3(90, player.transform.eulerAngles.y - 20f, player.transform.eulerAngles.z);
          
        }
        else if (gameObject.name.Contains("Right") || gameObject.name.Contains("R"))
        {

            transform.eulerAngles = new Vector3(90, player.transform.eulerAngles.y + 20f, player.transform.eulerAngles.z);
            
        }
        else
            transform.eulerAngles = new Vector3(90, player.transform.eulerAngles.y, player.transform.eulerAngles.z); 
    }
	
	void FixedUpdate () 
    {
        if (gameObject.name.Contains("L"))
        {
            transform.position += Vector3.Lerp(shootDirection, shootDirectionLeft, 0.25f) * speed * Time.deltaTime;
        }
        else if (gameObject.name.Contains("R"))
        {
            transform.position += Vector3.Lerp(shootDirection, shootDirectionRight, 0.25f) * speed * Time.deltaTime;
        }
        else
            transform.position += shootDirection * speed * Time.deltaTime;
	}

   

    public void setBulletDamage(float damage)
    {
        bulletDamage = damage;
    }

    public float getBulletDamage(float damage)
    {
        return bulletDamage;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("tree"))
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Enemy")
        {
            bulletDamage = playerStatus.attack;

            if (playerAbilities.getCurrPlayerName() == "Trevor")
                playerAbilities.trevorAbility(other.gameObject);
            else if (playerAbilities.getCurrPlayerName() == "Marcia")
                bulletDamage = playerAbilities.marciaAbility(other.gameObject,bulletDamage);

            currInventories = playerInventories.currItems();

            for (int i=0; i<currInventories.Length; i++)
            {
                
                if(currInventories[i].ToLower().CompareTo("rencong") == 0)
                {
                    int chance = Random.Range(0, 100);

                    if (chance < 15)
                        bulletDamage += (bulletDamage * 1.5f);

                    continue;            
                }
                if (currInventories[i].ToLower().CompareTo("bambu runcing") == 0)
                {
                    int chance = Random.Range(0, 100);

                    if (chance < 15)
                        bulletDamage += (bulletDamage * 2.5f);

                    continue;
                }
                if (currInventories[i].ToLower().CompareTo("orb of dedemit") == 0)
                {
                    playerStatus.AddHp(bulletDamage * 0.15f);
                    Debug.Log("Orb of Dedemit !!");
                    continue;
                }
                if(currInventories[i].ToLower().CompareTo("celurit") == 0)
                {
                   
                    other.gameObject.GetComponent<EnemyStatus>().armor -= 15f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>().DisplayEffect(other.gameObject,"- ARMOR",Color.red);
                    continue;
                }
                if(currInventories[i].ToLower().CompareTo("kuntil anak mask") == 0)
                {
                    Debug.Log("Dracula Vest");
                    playerStatus.AddHp(bulletDamage * 0.35f);
                }
            }

            bulletDamage = bulletDamage - other.gameObject.GetComponent<EnemyStatus>().armor / 2;

            other.gameObject.GetComponent<EnemyStatus>().GotDamaged(bulletDamage);



            Destroy(gameObject);
        }
    }

    void LookDirection()
    {
        if (StartupManager.isStarted)
        {

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, 200f, floorMask))
            {
               /* Vector3 playerToMouse = floorHit.point - transform.position;

                playerToMouse.x = 90f;
                playerToMouse.z = 90f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

                this.GetComponent<Rigidbody>().MoveRotation(newRotation);*/
                
            }
        }
    }


}
