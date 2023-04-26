using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float _speedRotate;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 

    public void MouseRotation()
    {
        float horizontal = Input.GetAxis("Mouse X");

        transform.Rotate(0, horizontal * _speedRotate * Time.deltaTime, 0);

    }
}
