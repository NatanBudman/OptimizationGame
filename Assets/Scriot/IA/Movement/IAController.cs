using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [SerializeField] private GrillaMovement Movement;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float CooldownMov;
    [SerializeField] float speed = 5f;

    private float CurrentMove;
    
    
    //shoot

    public Weapons Weapons;

    // Start is called before the first frame update
   

    private Vector3 newdirection;

    private void Start()
    {
        newdirection = Movement.StartNodo.transform.position;
        Look(newdirection, transform);

    }

    // Update is called once per frame
    void Update()
    {
        CurrentMove += Time.deltaTime;

        if (CurrentMove > CooldownMov)
        {
            newdirection = Movement.IAGrillaMove().position;
            Weapons.Shoot();
            Look(newdirection, transform);
            CurrentMove = 0;
        }

        if (transform.position != newdirection)
        {
            Vector3 direction = (newdirection - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;

            _rb.MovePosition(newPosition);
        }

    }

    private void Look(Vector3 target, Transform origin)
    {
        Vector3 direction = target.normalized - origin.position;
        direction.x = 0;
        direction.z = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

 

}
