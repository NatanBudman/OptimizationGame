using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;      
    
    public int poolSize = 10;                 

    private Queue<GameObject> bullets;         

    void Start()
    {
        bullets = new Queue<GameObject>();    

        // Instancia las balas y añádelas a la queue
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }
    }

    // Retorna una bala del pool
    public GameObject GetBullet()
    {
        if (bullets.Count == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }

        GameObject bulletToReturn = bullets.Dequeue();
        bulletToReturn.SetActive(true);

        return bulletToReturn;
    }

    // Devuelve una bala al pool
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }


}

