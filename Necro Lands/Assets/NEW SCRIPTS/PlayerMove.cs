using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private Rigidbody myRigidBody;
    private Animator anim;
    private Player myPlayer;
    public bool isNavigable;

    private VirtualJoystick JoyStick;
    private Vector2 MoveDirection;
    private ShootButton shootButton;
	// Use this for initialization
	void Start () 
    {
        myRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        myPlayer = GetComponent<Player>();
        isNavigable = true;
        JoyStick = VirtualJoystick.GetInstance();
        MoveDirection = new Vector2();
        shootButton = ShootButton.GetInstance();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!JoyStick)
        {
            JoyStick = VirtualJoystick.GetInstance();
        }

        Animating();
        if (isNavigable)
        {
           
                MoveDirection.x = JoyStick.GetInputVector().x;
                MoveDirection.y = JoyStick.GetInputVector().z;
                
                transform.LookAt(transform.position + JoyStick.GetInputVector() * 50f);
            
            if(JoyStick.GetInputVector().x != 0f || JoyStick.GetInputVector().z != 0f)
            {
                myRigidBody.MovePosition(transform.position + JoyStick.GetInputVector() * myPlayer.MoveSpeed * Time.deltaTime);
                myRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
            }
          
            if (Input.GetKey(KeyCode.W))
            {
                myRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
                myRigidBody.MovePosition(transform.position + Vector3.forward * myPlayer.MoveSpeed * Time.deltaTime);
                //transform.Translate(Vector3.forward * myPlayer.MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                myRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
                myRigidBody.MovePosition(transform.position + Vector3.left * myPlayer.MoveSpeed * Time.deltaTime);
                ///transform.Translate(Vector3.left * myPlayer.MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
                myRigidBody.MovePosition(transform.position + Vector3.back * myPlayer.MoveSpeed * Time.deltaTime);
                //transform.Translate(Vector3.back * myPlayer.MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                myRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
                myRigidBody.MovePosition(transform.position + Vector3.right * myPlayer.MoveSpeed * Time.deltaTime);
                //transform.Translate(Vector3.right * myPlayer.MoveSpeed * Time.deltaTime);
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && JoyStick.GetInputVector().x == 0f && JoyStick.GetInputVector().z == 0f)
            {
                myRigidBody.constraints = RigidbodyConstraints.FreezeAll;
            }
            LookRotation();
        }
      
       
	}

    void Animating()
    {
        anim.SetBool("Walking", (JoyStick.GetInputVector().x != 0f || JoyStick.GetInputVector().z != 0f) || ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))));
        //anim.SetBool("Walking", (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)));

        if (anim.GetBool("Shooting") != shootButton.Pressed)
        {
            anim.SetBool("Shooting", shootButton.Pressed);
        }
        //anim.SetBool("Shooting", Input.GetMouseButton(0));

        if (anim.GetBool("Dead") != (myPlayer.HP <= 0f))
        {
            anim.SetBool("Dead", (myPlayer.HP <= 0f));
        }
    }

    void LookRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObj;
        int groundMask = LayerMask.GetMask("Floor");
        if (Physics.Raycast(ray, out hitObj, 350f, groundMask))
        {
            Vector3 playerToMouse = hitObj.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion NewRotation = Quaternion.LookRotation(playerToMouse);
            myRigidBody.MoveRotation(NewRotation);
        }
    }
}
