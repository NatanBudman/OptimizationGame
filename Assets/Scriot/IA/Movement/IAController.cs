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

    public EnemyPool pool;
    [Header("Movement")]
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float CooldownMov;
    [SerializeField] float speed = 5f;

    private float CurrentMove;
    
    [Space]
    [Space]
    //shoot
    [Header("Weapon")]
    public Weapons Weapons;

    private Vector3 newdirection;
    
    

    
    // States
    private bool isPatrol = true;
    private bool isPlayerDetected = false;

    [Header("Detection")] 
    public int maxDectionEntiti = 3;
    public float angle;
    public float radius;
    public LayerMask LayerTarget;
    public LayerMask LayerObstacle;
    private EntitiDetectionColliders _detectionColliders;

    private void Start()
    {
        InicializeDetection();
        newdirection = Movement.StartNodo.transform.position;

    }

    public void UIUpdate()
    {
        
    }

    public void GameplayUpdate()
    {

        if (isPlayerDetected)
        {
            isPatrol = false;
        }
        
        if (isPatrol)
        {
             Move();
        }

        
        Detection();
        
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            gameObject.SetActive(false);

            pool.ReturnObject(gameObject);
        }
    }
    void Shoot()
    {
        Weapons.Shoot();
    }

    void InicializeDetection()
    {
        _detectionColliders = new EntitiDetectionColliders(transform, LayerTarget, LayerObstacle, radius, angle ,maxDectionEntiti);
    }

    void Detection()
    {
        
        GameObject entiti = _detectionColliders.GetEntiti();

        if (entiti != null)
        {
            isPlayerDetected = true;
            
            Shoot();

        }
        else
        {
            isPatrol = true;
            isPlayerDetected = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * radius);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * radius);
        
  
        
     
    }
}
