using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> enemyList = new List<GameObject>();

    private int amountEnemy = 50;

    [SerializeField] private GameObject[] enemyPrefab;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        for (int j = 0; j < enemyPrefab.Length; j++)
        {
            for (int i = 0; i < amountEnemy; i++)
            {
                GameObject obj = Instantiate(enemyPrefab[j]);
                obj.SetActive(false);
                enemyList.Add(obj);
            }
        }
    }

    public GameObject getPoolObject()
    {
        for (int i = SpawnManager.instance.counterListEnemy; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
            {
                return enemyList[i];
            }
        }
        return null;
    }
}
