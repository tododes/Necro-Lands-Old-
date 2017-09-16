using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndlessLevelButton : MonoBehaviour {

    public int StartingLevel;
    public string RecordKey;
    public string name;

    //private Transform parentTransform;

    void Start()
    {
       StartingLevel = PlayerPrefs.GetInt(RecordKey);
    }

  

  /*  public void StartGrowingUp()
    {
        StartCoroutine(GrowingUp());
    }

    IEnumerator GrowingUp()
    {
        while(transform.localScale.x < 0.5f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.75f * Time.deltaTime, transform.localScale.y + 0.75f * Time.deltaTime, transform.localScale.z);
            yield return new WaitForSeconds(0.0167f);
        }
        yield return null;
    }

   */
}
