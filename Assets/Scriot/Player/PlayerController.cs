using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdates
{
    [Header("Mov") ]
    public Rigidbody rb;
    public float speed = 5f;
    public float fireRate = 1f;
    private float currentFireRate;
    
    [Space]
    [Header("GrillaMovement")]
    [Space]
    public GrillaMovement GrillaMovement;

    private Vector3 newPos;

    #region Inputs

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Pause;

    #endregion

    [Space] [Space] 
    [SerializeField]private GameManager _manager;
    
    [SerializeField] Transform playerSpawn;
    [Header("Shoot") ]
    private Vector3 direction = Vector3.zero;
    public Weapons Weapons;

    [Header("Health")] 
    public HealthController HealthController;

    private void Start()
    {
        //caching, este rigidboy lo utilizo varias veces en la funcion Move
        rb = GetComponent<Rigidbody>();

        newPos = transform.position;
        
        currentFireRate = fireRate;
    }

    private bool isCanMove()
    {
        bool isMove = (Vector3.Distance(transform.position,newPos) < 5);

        return isMove;
    }

    void MoveGrilla()
    {

        if (isCanMove())
        {
            if (GrillaMovement.PlayerGrillaMovement(Up,Down,Left,Right).position != null)
            {
                newPos = GrillaMovement.PlayerGrillaMovement(Up,Down,Left,Right).position;
            }
        }

        if (transform.position != newPos)
        {
            if (newPos != null)
            {
                Vector3 direction = (newPos - transform.position).normalized;
                Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;

                rb.MovePosition(newPosition);
            }
         
        }
    }
 
    void Shoot()
    {
        if (Weapons.isCanShoot())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Weapons.Shoot();
            }
        }
    }


    public void UIUpdate()
    {
      
    }

    public void GameplayUpdate()
    {
        if (Input.GetKey(Pause))
        {
            _manager.Pause(true);
        }
        
        Shoot();

        MoveGrilla();
        //Move();

        CheckLife();
    }

    private void CheckLife()
    {
        if (HealthController.isDeath())
        {
            GrillaMovement._currentNodo = GrillaMovement.StartNodo;
            newPos = GrillaMovement._currentNodo.transform.position;

            transform.position = new Vector3(playerSpawn.position.x,playerSpawn.position.y + 2.5f,playerSpawn.position.z);
            
            HealthController.Revive();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Proyectil")
        {
            collision.collider.GetComponent<HealthController>().Damage(1);
            HealthController.Damage(1);
        }
    }
}
