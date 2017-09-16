using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour{
    public GameObject bullet, bulletLeft, bulletRight;
    public float bulletLifeDuration = 3f;

    private float timer;
    private Status playerStatus;
    private LineRenderer gunLine;
    private Light gunLight;
	private PlayerActiveSkill skill;

    Ray ShootRay;
    int floorMask = 200;
    /*  RaycastHit hit;
     int ShootableMask;
     ParticleSystem gunParticle;*/


    // Use this for initialization
    void Start () {
        //ShootableMask = LayerMask.GetMask("Shootable");
        timer = 0f;
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
		skill = GetComponentInParent<PlayerActiveSkill> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (StartupManager.isStarted)
        {
            
            ShootRay.origin = transform.position;
            ShootRay.direction = transform.forward;
            timer += Time.deltaTime;
          
            if (Input.GetButton("Fire1") && timer > playerStatus.shootRate)
            {
               
            }
            else
            {
                Effects(false);
            }

        }

       

    }

    void Effects(bool enable)
    {
        gunLight.enabled = enable;
        gunLine.enabled = enable;
    }

    /*void Shooting()
    { 
   
        if (StartupManager.isStarted)
        {
        
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, 200f, floorMask))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;

                playerToMouse.y = 0f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

                //body.MoveRotation(newRotation);
            }
        }
    
    }*/
}