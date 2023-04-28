using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrillaMovement : MonoBehaviour
{
    public Nodo StartNodo;
    private Nodo _currentNodo;

    private void GetNeighborNodes()
    {
        _currentNodo.GetNeighborNodes();
    }

    private void Start()
    {
        _currentNodo = StartNodo;
        GetNeighborNodes();
    }

    public Transform IAGrillaMove()
    {
        GetNeighborNodes();
        
        Transform _nodoPos = default;
        
        int lenght = _currentNodo.Neighbor.Length;
        int random = Random.Range(0, lenght);
        
        Nodo newcurr = _currentNodo.Neighbor[random];
        
        _nodoPos = newcurr.transform;

        _currentNodo = newcurr;
                
        return _nodoPos;

    }
}
