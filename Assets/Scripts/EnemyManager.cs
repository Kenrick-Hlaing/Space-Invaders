using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform environmentRoot;
    public GameObject enemyPrefab;
    public GameObject enemyRank2Prefab;
    public GameObject enemyRank3Prefab;
    public GameObject enemyRank4Prefab;
    public float spawnWidth = 1f;
    public float spawnHeight = 1f;
    public int enemyRows = 3;
    public int enemyColumns = 3;
    public float stutterDistance = 0.5f;
    public float maxStutterSpeed = 0.07f;

    private float stutterSpace;
    private float enemyNumber;
    private float stutterTime;
    private List<GameObject> prefabList;
    // Start is called before the first frame update
    void Start()
    {
        prefabList = new List<GameObject> { enemyPrefab, enemyRank2Prefab, enemyRank3Prefab, enemyRank4Prefab };
        LoadEnemy();
        enemyNumber = enemyRows * ((2*enemyColumns) + 1);
        stutterTime = 1.0f;
        Enemy.OnEnemyDied += StutterIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        // use enemyRows, enemyColumns, spawnHeight, spawnWidth
        // to know the bounds of the object
        if(Time.time - stutterSpace >= stutterTime){
            stutterSpace = Time.time;
            float width = 0.5f + ((enemyColumns - 1) * spawnWidth);
            if(transform.position.x + width <= 8.5 && transform.position.x - width >= -8.5f){
                transform.position  = new Vector3(transform.position.x + stutterDistance, transform.position.y, 0f);
            } else {
                stutterDistance *= -1;
                transform.position  = new Vector3(transform.position.x + stutterDistance, transform.position.y - 0.5f, 0f);
            }
        }
    }

    private void LoadEnemy()
    {
        for(int i = 0; i > -enemyRows; i--){
            Vector3 newPos = new Vector3(0f, transform.position.y + (i * spawnHeight), 0f);
            int randomIndex = Random.Range(0, prefabList.Count);
            Instantiate(prefabList[randomIndex], newPos, Quaternion.identity, environmentRoot);
        }
        for(int i = 0; i > -enemyRows; i--){
            int randomIndex = Random.Range(0, prefabList.Count);
            for(int j = 1; j < enemyColumns; j++){
                Vector3 newPos = new Vector3(transform.position.x + (j * spawnWidth),
                                             transform.position.y + (i * spawnHeight), 0f);
                Instantiate(prefabList[randomIndex], newPos, Quaternion.identity, environmentRoot);
                newPos = new Vector3(transform.position.x - (j * spawnWidth),
                                     transform.position.y + (i * spawnHeight), 0f);
                Instantiate(prefabList[randomIndex], newPos, Quaternion.identity, environmentRoot);
            }
        }
    }

    private void StutterIncrease(int pointWorth){
        enemyNumber--;
        if(stutterTime > maxStutterSpeed){
            stutterTime = stutterTime * (enemyNumber / (enemyRows * ((2*enemyColumns) + 1)));
        }
    }
}
