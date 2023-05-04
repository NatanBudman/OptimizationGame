using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour,IUpdates
{
    [SerializeField] private GrillaMovement Movement;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float CooldownMov;
    [SerializeField] float speed = 5f;

    private float CurrentMove;
    
    
    //shoot

    public Weapons Weapons;

    private Vector3 newdirection;


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


    private void Look(Vector3 target, Transform origin)
    {
        Vector3 direction = target.normalized - origin.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation.z = 0;
        rotation.x = 0;
        transform.rotation = rotation;
    }


    public void UIUpdate()
    {
        
    }

    public void GameplayUpdate()
    {
        Move();
        Detection();
    }

    void Move()
    {
        CurrentMove += Time.deltaTime;
        if (CurrentMove > CooldownMov)
        {
            newdirection = Movement.IAGrillaMove().position;
            //Look(newdirection, transform);
            CurrentMove = 0;
        }

        if (transform.position != newdirection)
        {
            Vector3 direction = (newdirection - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;

            _rb.MovePosition(newPosition);
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
            Shoot();

            Look(entiti.transform.position,transform);
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
