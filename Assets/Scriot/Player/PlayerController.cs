using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdates
{
    [Header("Mov") ]
    public float _speedRotate;
    public Rigidbody rb;
    public float speed = 5f;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    
    [Header("Shoot") ]
    [ SerializeField]private Shooter _shooter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 

    public void MouseRotation()
    {
        float horizontal = Input.GetAxis("Mouse X");

        transform.Rotate(0, horizontal * _speedRotate * Time.deltaTime, 0);

    }

    private void Move()
    {
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        */
        var horizontal = Input.GetAxis("Horizontal");  // valor de entrada horizontal
        var vertical = Input.GetAxis("Vertical");  // valor de entrada vertical
 
// obtener la dirección de movimiento basada en la rotación del objeto
        var movement = transform.forward * vertical + transform.right * horizontal;
 
// normalizar la dirección y multiplicar por la velocidad para obtener la velocidad del movimiento
        movement = movement.normalized * speed;
 
// mover el objeto usando rb.MovePosition()
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }

    public void UIUpdate()
    {
       
    }

    public void GameplayUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            GameObject projectile = Instantiate(_shooter.projectilePrefab, _shooter.projectileSpawnPoint.position, Quaternion.identity);

            Vector3 directionBullet = transform.forward;

            projectile.GetComponent<Rigidbody>().velocity = directionBullet * _shooter.projectileSpeed;
        }

        MouseRotation();
        Move();
    }
}
