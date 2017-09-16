using UnityEngine;
using System.Collections;

public class EnemyMovementInStory : MonoBehaviour {

    private Animator anime;
	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
        anime.SetBool("walk", true);
    }
	
	// Update is called once per frame
	void Update () {
        if (StoryState.counter == 6)
        {
            if (transform.position.z > 45f)
            {
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);
            }
            else
            {
                StoryState.skipPermitted = true;
                if (StoryState.counter == 6)
                    StoryState.counter++;
            }
        }
        
    }
}
