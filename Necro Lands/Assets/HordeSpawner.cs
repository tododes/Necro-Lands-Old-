using UnityEngine;
using System.Collections;

public class HordeSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] EnemyHorde;
    private HordeWarning warning;

    [SerializeField]
    private int HordeInterval;

    IEnumerator SpawnHorde()
    {
        int r;
        for(int i = 0; i < 10;i++)
        {
            yield return new WaitForSeconds(HordeInterval);
            for (int j = 0; j < 12;j++)
            {
                r = Random.Range(0, EnemyHorde.Length);
                Instantiate(EnemyHorde[r], transform.position, Quaternion.identity);
            }
            warning.StartDisplayText();
        }
        yield return null;
    }
	// Use this for initialization
	void Start () 
    {
        warning = HordeWarning.GetHordeWarning();
        StartCoroutine(SpawnHorde());
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
