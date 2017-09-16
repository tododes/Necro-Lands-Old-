using UnityEngine;
using System.Collections;

public class DefendingFrenzy : MonoBehaviour {

    public int min;
    public int sec;
	// Use this for initialization
	protected void Start () 
    {
        StartCoroutine(Timer());
	}

    protected IEnumerator Timer()
    {
        while (min > 0 || sec > 0)
        {
            sec--;
            if (sec < 0)
            {
                min--;
                sec = 59;
            }
            yield return new WaitForSeconds(1);    
        }
        EndingTask();
        yield return null;
    }

    public virtual void EndingTask()
    {
        GameManager.Win = true;
    }
}
