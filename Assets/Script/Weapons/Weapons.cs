using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public Transform FirePoint;

    public BulletPool Pool;

    public float FireRate;
    private float currentFireRate;
    

    public bool isCanShoot()
    {
        if (currentFireRate < FireRate + 1) currentFireRate += Time.deltaTime;

        return currentFireRate > FireRate;
    }
    public void Shoot()
    {

        if (isCanShoot())
        {
            SpawnBullet();
            
            currentFireRate = 0;
        }
    }
    
    
// El tipo de bala se define por el tipo de pool que le pongas
// optimizacion de Precomputation, ya que tanto en Shoot, como en isCanShoot utilizo la funcion del SpawnBullet, como en la IAController. En vez de escribir dos veces todo el codigo
    void SpawnBullet()
    {
        GameObject newBullet = Pool.GetBullet();
        newBullet.GetComponent<Bullet>().Pool = Pool;
        newBullet.GetComponent<UpdateManagerGameplay>().AddManager();
        newBullet.transform.position = FirePoint.position;
        newBullet.transform.rotation = FirePoint.rotation;
    }
}
