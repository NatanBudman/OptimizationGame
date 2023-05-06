using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int poolSize = 5;


    private Queue<GameObject> poolEnemies;

    private void Awake()
    {
        poolEnemies = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject _enemy = Instantiate(enemyPrefab, transform);
            _enemy.SetActive(false);
            poolEnemies.Enqueue(_enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        GameObject enemy;

        if (poolEnemies.Count > 0)
        {
            enemy = poolEnemies.Dequeue();
            enemy.SetActive(true);
           
        }
        else
        {
            enemy = Instantiate(enemyPrefab);

        }

        return enemy;
    }

    public void ReturnObject(GameObject enemy)
    {
        enemy.SetActive(false);
        poolEnemies.Enqueue(enemy);
    }
}

