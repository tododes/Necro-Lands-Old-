using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

    [SerializeField]
	protected float spawnInterval;

    [SerializeField]
    protected float firstSpawnInterval;

    protected float NextWaveInterval;
    protected Text waveText;
    protected Player player;

	protected void Awake()
	{
        firstSpawnInterval = Random.Range(10, 20);
	}
    protected void Start()
    {
        StartCoroutine(Spawn());
    }

	protected virtual void Update()
	{
		
	}

    protected IEnumerator Spawn()
    {
        if (!player)
            player = FindObjectOfType<Player>();
        yield return new WaitForSeconds(firstSpawnInterval);
        while (player.HP > 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return null;
    }
	
		
	
}
