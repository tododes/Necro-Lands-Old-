using UnityEngine;
using System.Collections;

public class InfoSceneButton : MonoBehaviour {

    public float DestinationOfY;
    private EnemyDemoCamera OurCamera;
    
	// Use this for initialization
	void Start () 
    {
        //DestinationOfY = 1f;
        OurCamera = Camera.main.gameObject.GetComponent<EnemyDemoCamera>();
	}

    public void SetDesY()
    {
        OurCamera.DestinationY = DestinationOfY;
        if (DestinationOfY >= 60f)
        {
            OurCamera.CSTATE = EnemyDemoCamera.CAMERASTATE.GAMEPLAYINFO;
        }
        else if (DestinationOfY >= 30f)
        {
            OurCamera.CSTATE = EnemyDemoCamera.CAMERASTATE.ITEMINFO;
        }
        else if (DestinationOfY <= 1f)
        {
            OurCamera.CSTATE = EnemyDemoCamera.CAMERASTATE.ENEMYINFO;
        }
    }
}
