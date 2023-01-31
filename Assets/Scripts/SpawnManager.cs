using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    // [SerializeField] public List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private GameObject[] spawnPoints;

    // [SerializeField] private GameObject runEnemy,enemyParent;

    [SerializeField] private float maxEnemyCount, enemyCreateCount;
    private int index, i = 0;
    private float timer;
    [Tooltip("EnemyListte hangi sýradan oluþuma devam edeceðini gösterir.")]
    public int counterListEnemy;
    public bool enemyCreateFinish;

    [Header("Enemy Spawn Manager")]
    [SerializeField] private float[] enemyCreateTime;
    [Tooltip("Listedeki hangi Enemyden baþlayacaðýmýzý seçiyoruz.")]
    public int[] listEnemyTurn;

    [SerializeField] private GameObject levelBOSS;

    SpawnManager spawnManager;


    // GameObject runEnemyClone;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        // enemyCreateTime = (enemyCreateTime * 60) / 100;
        counterListEnemy = 0;
    }
    private void FixedUpdate()
    {
        if (timer >= enemyCreateTime[i] && !enemyCreateFinish)
        {
            if (enemyCreateCount >= maxEnemyCount)
            {
                i++;

                if (i >= listEnemyTurn.Length)
                {
                    Instantiate(levelBOSS, spawnPoints[index].transform.position, transform.rotation);
                    ObjectPool.instance.enemyList.Add(levelBOSS);
                    spawnManager.enabled = false;
                }

                enemyCreateCount = 0;
                counterListEnemy = listEnemyTurn[i];

                // Debug.Log(enemyCreateCount + " Enemy");
                // enemyCreateFinish = true;
            }
            else
            {
                timer = 0f;
                index = Random.Range(0, spawnPoints.Length);

                GameObject runEnemyClone = ObjectPool.instance.getPoolObject();

                if (runEnemyClone != null)
                {
                    Debug.Log("New enemy Created.");
                    runEnemyClone.transform.position = spawnPoints[index].transform.position;
                    runEnemyClone.SetActive(true);
                }

                enemyCreateCount += 1;
            }


        }
        else timer += 0.01f;

    }
}
