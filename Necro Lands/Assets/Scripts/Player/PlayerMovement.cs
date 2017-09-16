using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speedDampTime = 0.01f;
    private GameObject gameController;

    private Rigidbody body;
    private int floorMask;
    private Status playerStatus;
    private Animator anim;
    private HashIDs hash;

	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("Game Controller");
        body = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        playerStatus = GetComponent<Status>();
        anim = GetComponent<Animator>();
        hash = gameController.GetComponent<HashIDs>();

        anim.SetLayerWeight(1, 1f);
	}
	
    void Update()
    {
        if (StartupManager.isStarted)
        {
            bool shoot = Input.GetButton("Fire1");
            anim.SetBool(hash.shootingBool, shoot);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (StartupManager.isStarted)
        {

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 newPosition = new Vector3(h, 0, v);

            if (h != 0 || v != 0)
            {
                anim.SetFloat(hash.speedFloat, playerStatus.speed, speedDampTime, Time.deltaTime);
            }
            
            else
                anim.SetFloat(hash.speedFloat, 0);

            if (Input.GetKey(KeyCode.Space))
            {
                body.MovePosition(transform.position + (newPosition.normalized * (playerStatus.speed+2.5f) * Time.deltaTime));
            }
            else
                body.MovePosition(transform.position + (newPosition.normalized * playerStatus.speed * Time.deltaTime));


            LookDirection();
			//transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"),0));
        }
	}
    
    void LookDirection()
    {
        if (StartupManager.isStarted)
        {
        
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, 150f, floorMask))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;

                playerToMouse.y = 0f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

                body.MoveRotation(newRotation);
            }
        }
    }
}
