using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrillaMovement : MonoBehaviour
{
    public Nodo StartNodo;
    public Nodo _currentNodo;

    private void GetNeighborNodes()
    {
        _currentNodo.GetNeighborNodes();
    }

  

    private void Start()
    {
        GetInitialNodo();
        _currentNodo = StartNodo;
        GetNeighborNodes();
    }

    private void GetInitialNodo()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        
             
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.gameObject.GetComponent<Nodo>().isWalkable)
            {
                StartNodo = hit.collider.gameObject.GetComponent<Nodo>();
            }
        }
    }

    public Transform IAGrillaMove()
    {
       GetNeighborNodes();
        
        Transform _nodoPos = default;
        
        int lenght = _currentNodo.Neighbor.Length;
        int random = Random.Range(0, lenght - 1);
        
        Nodo newcurr = _currentNodo.Neighbor[random];
        
        _nodoPos = newcurr.transform;

        _currentNodo = newcurr;
                
        return _nodoPos;

    }
}
