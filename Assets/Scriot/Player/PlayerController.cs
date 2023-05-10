using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdates
{
    [Header("Mov") ]
    public Rigidbody rb;
    public float speed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    public float smoothTime = 0.3f;
    public float fireRate = 1f;
    private float currentFireRate;
    [SerializeField] Transform playerSpawn;
    [Header("Shoot") ]
    private Vector3 direction = Vector3.zero;
    public Weapons Weapons;



    private void Start()
    {
        //caching, este rigidboy lo utilizo varias veces en la funcion Move
        rb = GetComponent<Rigidbody>();


        currentFireRate = fireRate;
    }


   
    private void Move()
    {       
        var horizontal = Input.GetAxis("Horizontal");  // valor de entrada horizontal
        var vertical = Input.GetAxis("Vertical");  // valor de entrada vertical

        //lazy computation
        if (horizontal != 0 || vertical != 0)
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
        }else
        {
            direction = Vector3.zero;
            rb.velocity = Vector3.zero; 
        }

        Vector3 velocity = direction * speed * Time.deltaTime;
        rb.MovePosition(rb.position + velocity);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


    }


    void ShootP()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Weapons.Shoot();

        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Proyectil"))
        {

            //Destroy(this.gameObject);
                transform.position = playerSpawn.position;
                

            

        }
    }

    public void UIUpdate()
    {
       
    }

    public void GameplayUpdate()
    {     
        ShootP();
        Move();
    }

    


}
