using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour,IUpdates
{
    [SerializeField] private GrillaMovement Movement;
    [SerializeField] private IAModel _model;
    
    [Space]
    [Space]
    
    [Header("Movement")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float CooldownMov;
    [SerializeField] float speed = 5f;

    
    [Space]
    [Space]
    
    //shoot
    [Header("Weapon")]
    public Weapons Weapons;

    private Vector3 newdirection;

    private EnemyPool Pool;
    private float CurrentMove;

    private void Start()
    {
        newdirection = Movement.StartNodo.transform.position;

    }

    public void UIUpdate()
    {
        
    }

    public void GameplayUpdate()
    {
        Move();

        Shoot();
    }
   

    void Move()
    {

        CurrentMove += Time.deltaTime;

        
        
        if (CurrentMove > CooldownMov)
        {
            newdirection = Movement.IAGrillaMove().position;
            CurrentMove = 0;
        }

        if (transform.position != newdirection)
        {
            if (_model.isSeeNodo(Movement._currentNodo.gameObject))
            {
                Vector3 direction = (newdirection - transform.position).normalized;
                Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;

                _rb.MovePosition(newPosition);
            }
            else
            {
                _model.Look(newdirection, transform);
            }

        }
    }

    void Shoot()
    {
        if (Weapons.isCanShoot())
        {
            Weapons.Shoot();

        }
    }
    void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.CompareTag("Proyectil") || collision.gameObject.CompareTag("Player"))
        {
            GameObject poolEnemies = GameObject.Find("EnemyPool");
            EnemyPool enemyPool = poolEnemies.GetComponent<EnemyPool>();
            enemyPool.ReturnObject(gameObject);
        }
    }

}
