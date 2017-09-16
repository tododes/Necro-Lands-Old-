using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour 
{
    [SerializeField]
    private List<GameObject> MorningEnemyPool = new List<GameObject>();
    [SerializeField]
    private List<GameObject> NoonEnemyPool = new List<GameObject>();
    [SerializeField]
    private List<GameObject> AfternoonEnemyPool = new List<GameObject>();
    [SerializeField]
    private List<GameObject> NightEnemyPool = new List<GameObject>();
    [SerializeField]
    private List<GameObject> DawnEnemyPool = new List<GameObject>();
    private Player OurPlayer;
    public static int spawnScale;
    public float spawnDelay;
    public int counter;
    public int startingScaleSpawn;
    public bool threadStarted;

    public string SceneScaleSaveKey;

    void Start()
    {
        if(Application.loadedLevelName.Contains("Mega"))
           SceneScaleSaveKey = "Mega Boss Scale Record";
        else if (Application.loadedLevelName.Contains("Boss"))
            SceneScaleSaveKey = "Boss Scale Record";
        else
            SceneScaleSaveKey = "Scale Record";

        spawnScale = PlayerPrefs.GetInt(SceneScaleSaveKey);

        threadStarted = false;
        OurPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //counter = 0;
        //for (int i = 0; i < 20; i++)
        //{
        //    GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation) as GameObject;
        //    newEnemy.SetActive(false);
        //    //EnemyPool.Add(newEnemy);
        //}
        
    }

    void Update()
    {
        if (spawnScale >= startingScaleSpawn && !threadStarted)
        {
            StartCoroutine(SpawnEnemies());
            threadStarted = true;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while(OurPlayer.HP > 0)
        {
            if(TimeManager.GetInstance().Morning)
            {
                int r = Random.Range(0, MorningEnemyPool.Count);
                Instantiate(MorningEnemyPool[r].gameObject, transform.position, Quaternion.identity);
            }
            else if (TimeManager.GetInstance().Noon)
            {
                int r = Random.Range(0, NoonEnemyPool.Count);
                Instantiate(NoonEnemyPool[r].gameObject, transform.position, Quaternion.identity);
            }
            else if (TimeManager.GetInstance().Afternoon)
            {
                int r = Random.Range(0, AfternoonEnemyPool.Count);
                Instantiate(AfternoonEnemyPool[r].gameObject, transform.position, Quaternion.identity);
            }
            else if (TimeManager.GetInstance().Night)
            {
                int r = Random.Range(0, NightEnemyPool.Count);
                Instantiate(NightEnemyPool[r].gameObject, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }

    //IEnumerator SpawnEnemies()
    //{
    //    //while (OurPlayer.HP > 0)
    //    //{
    //    //    EnemyPool[counter].SetActive(true);
    //    //    counter++;
    //    //    if (counter >= EnemyPool.Count)
    //    //        counter = 0;
    //    //    spawnScale++;
    //    //    yield return new WaitForSeconds(spawnDelay);
    //    //}
    //    //yield return null;
    //}
    /*public GameObject[] enemies;
    public int spawnDelay;
    private Player OurPlayer;
    public static int spawnScale;

    void Start()
    {
        spawnScale = 0;
        OurPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (OurPlayer.HP > 0)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
                yield return new WaitForSeconds(1.2f);
            }
            spawnScale++;
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }*/
}

