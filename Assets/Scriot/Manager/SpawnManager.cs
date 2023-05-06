using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour, IUpdates
{
    [Header("SpawnPoints") ]
    public Nodo[] EnemySpawns;
    public Nodo playerSpawn;
    
    [Space(5)]

    [Header("Prefabs")] 
    [Space(2)]
    public GameObject Enemies;
    public GameObject Player;

    [Header("Paramatros")]
    [Space(2)]
    public int EnemyCount;
    private int _CurrentEnemies;
    [Space(2)]
    public float CoolwdownEnemieInstantiate;
    private float _CurrentEnemieInstantiate;
    public bool IsMaxEntities;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;

    public EnemyPool enemyPool;

    int maxEntities = 4;
    //[]
    void Start()
    {
        _CurrentEnemies = EnemyCount;

        enemyPool = GetComponent<EnemyPool>();
        _colliders = new Collider[maxEntities];
    }

    public void UIUpdate()
    {
        
    }

    public void GameplayUpdate()
    {
        int countObstacle = Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _layerMask);
        if (countObstacle < 3)
        {
            Spawner();
        }
        for (int i = 0; i < countObstacle; i++)
        { }

    }

    public void Spawner()
    {
        // pasar esto cuando el UpdateGameplay esta puesto en escena
        _CurrentEnemieInstantiate += Time.deltaTime;
        if (_CurrentEnemieInstantiate > CoolwdownEnemieInstantiate)
        {
            var random = Random.Range(0, EnemySpawns.Length);
            Vector3 pos = new Vector3(EnemySpawns[random].transform.position.x,
                EnemySpawns[random].transform.position.y + 1f, EnemySpawns[random].transform.position.z);

            GameObject instantiatedEnemy = enemyPool.GetPooledEnemy();
            if (instantiatedEnemy != null)
            {
                instantiatedEnemy.transform.position = pos;
                instantiatedEnemy.SetActive(true);
            }
            else
            {

                //tendriamos q poner la derrota
                Debug.Log("no mas enemigos");
            }

            //GameObject InstantiateOBJ = Instantiate(Enemies, pos, Quaternion.identity);
            //  InstantiateOBJ.GetComponent<GrillaMovement>().StartNodo = EnemySpawns[random];
            _CurrentEnemieInstantiate = 0;
        }
    }
}
