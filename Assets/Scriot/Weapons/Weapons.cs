using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public Transform FirePoint;

    public BulletPool Pool;

    public float FireRate;
    private float currentFireRate;

    public void Shoot()
    {
        currentFireRate += Time.deltaTime;

        if (currentFireRate > FireRate)
        {
            SpawnBullet();
            
            currentFireRate = 0;
        }
    }
    
    
// El tipo de bala se define por el tipo de pool que le pongas
    void SpawnBullet()
    {
        GameObject newBullet = Pool.GetBullet();
        newBullet.GetComponent<Bullet>().Pool = Pool;
        newBullet.transform.position = FirePoint.position;
        newBullet.transform.rotation = FirePoint.rotation;
    }
}
