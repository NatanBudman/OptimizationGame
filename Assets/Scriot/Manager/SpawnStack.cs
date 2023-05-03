using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStack : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int initialEnemyCount = 5;
    [SerializeField] private int maxEnemyCount = 10;
    [SerializeField] private float spawnDelay = 1f;

    private List<GameObject> enemyPool;

    private void Start()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < initialEnemyCount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.SetActive(false);
            enemyPool.Add(newEnemy);
        }

        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            if (enemyPool.Count < maxEnemyCount)
            {
                GameObject newEnemy = GetEnemyFromPool();
                newEnemy.transform.position = transform.position;
                newEnemy.SetActive(true);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private GameObject GetEnemyFromPool()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);

        return newEnemy;
    }

    /*

     private Stack<GameObject> enemyStack;

     private void Start()
     {
         enemyStack = new Stack<GameObject>();

         for (int i = 0; i < initialEnemyCount; i++)
         {
             SpawnEnemy();
         }
         StartCoroutine(SpawnEnemyCoroutine());
     }

     private IEnumerator SpawnEnemyCoroutine()
     {
         while (true)
         {
             if (enemyStack.Count < maxEnemyCount)
             {
                 SpawnEnemy();
             }

             yield return new WaitForSeconds(spawnDelay);
         }
     }

     private void SpawnEnemy()
     {
         GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
         enemyStack.Push(newEnemy);
     }
    */
}
