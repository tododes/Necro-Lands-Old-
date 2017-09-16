using UnityEngine;
using System.Collections;

public class EnemyBodyRender : MonoBehaviour {

    private SkinnedMeshRenderer myMesh;
    private Transform player;

    void Start()
    {
        myMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        /*if (Vector3.Distance(transform.position, player.position) >= 170f && myMesh.enabled)
        {
            myMesh.enabled = false;
        }
        else if (Vector3.Distance(transform.position, player.position) < 170f && !myMesh.enabled)
        {
            myMesh.enabled = true;
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            if (Vector3.Distance(transform.position, player.position) >= 170f && myMesh.enabled)
            {
                myMesh.enabled = false;
            }
            else if (Vector3.Distance(transform.position, player.position) < 170f && !myMesh.enabled)
            {
                myMesh.enabled = true;
            }
        }
   
    }

}
