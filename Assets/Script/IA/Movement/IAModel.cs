
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAModel : MonoBehaviour
{
    public void Look(Vector3 target, Transform origin)
    {
        Vector3 direction = target - origin.position;
        direction.y = 0f;
        transform.LookAt(transform.position + direction, Vector3.up);
    }
    
    public bool isSeeNodo(GameObject objectsee)
    {
        bool isSeeNodo = false;
        
        Transform playerTransform = GetComponent<Transform>();

        Collider objectCollider = objectsee.GetComponent<Collider>();

        Vector3 playerToObject = objectCollider.bounds.center - playerTransform.position;

        Vector3 playerForward = playerTransform.forward.normalized;

        float dotProduct = Vector3.Dot(playerForward, playerToObject.normalized);

        if (dotProduct > 0.5f)
        {
            isSeeNodo = true;
        }

        return isSeeNodo;
    }

}
