using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [SerializeField] private GrillaMovement Movement;
    [SerializeField] private Rigidbody _rb;

    [SerializeField]
    private float CooldownMov;
    [SerializeField] float speed = 5f;
    private float CurrentMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 newdirection;
    // Update is called once per frame
    void Update()
    {
        CurrentMove += Time.deltaTime;

        if (CurrentMove > CooldownMov)
        {
             newdirection = Movement.IAGrillaMove().position;
            
            CurrentMove = 0;
        }

        if (transform.position != newdirection)
        {
            Vector3 direction = (newdirection - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;

            _rb.MovePosition(newPosition);
            transform.LookAt(newPosition);
        }
      
    }
}
