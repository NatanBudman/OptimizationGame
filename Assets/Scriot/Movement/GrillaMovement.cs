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
// Usamos el Movimiento por diccionario para optimizar el acceso a los vecinos de cada nodo
    public void GetInitialNodo()
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
        // agrego los vecinos al Diccionario
       GetNeighborNodes();
        
        Transform _nodoPos = default;
        Nodo newcurr = _currentNodo;
        
        int lenght = _currentNodo.NodosConection.Count;
        int random = Random.Range(0, lenght);

        switch (random)
        {
            case 0:
                if (_currentNodo.NodosConection.ContainsKey("Up"))
                {
                    if (_currentNodo.NodosConection["Up"].isWalkable)
                    {
                        newcurr = _currentNodo.NodosConection["Up"];
                
                        LookNodo("Up");
                    }
               
                }
                break;
            case 1:
                if (_currentNodo.NodosConection.ContainsKey("Down"))
                {
                    if (_currentNodo.NodosConection["Down"].isWalkable)
                    {
                        newcurr = _currentNodo.NodosConection["Down"];
                
                        LookNodo("Down");
                    }
                }
                break;
            case 2:
               
                if (_currentNodo.NodosConection.ContainsKey("Left"))
                {
                    if (_currentNodo.NodosConection["Left"].isWalkable)
                    {
                        newcurr = _currentNodo.NodosConection["Left"];
                
                        LookNodo("Left");
                    }
                }
                break;
            case 3:
                if (_currentNodo.NodosConection.ContainsKey("Right"))
                {
                    if (_currentNodo.NodosConection["Right"].isWalkable)
                    {
                        newcurr = _currentNodo.NodosConection["Right"];
                
                        LookNodo("Right");
                    }
                }
             
                break;
        }
        
        _nodoPos = newcurr.transform;

        _currentNodo = newcurr;
                
        return _nodoPos;

    }

    public Transform PlayerGrillaMovement(KeyCode Up,KeyCode Down,KeyCode Left, KeyCode Right)
    {
        GetNeighborNodes();
        
        Transform _nodoPos = _currentNodo.transform;

        Nodo newcurr = _currentNodo;
        
        if (Input.GetKeyDown(Up))
        {
            if (_currentNodo.NodosConection.ContainsKey("Up"))
            {
                if (_currentNodo.NodosConection["Up"].isWalkable)
                    newcurr = _currentNodo.NodosConection["Up"];
                
                LookNodo("Up");

            }
            
        }
        if (Input.GetKeyDown(Down))
        {
            if (_currentNodo.NodosConection.ContainsKey("Down"))
            {
                if (_currentNodo.NodosConection["Down"].isWalkable)
                    newcurr = _currentNodo.NodosConection["Down"];
                
                LookNodo("Down");

            }
        }
        if (Input.GetKeyDown(Left))
        {
            if (_currentNodo.NodosConection.ContainsKey("Left"))
            {
                if (_currentNodo.NodosConection["Left"].isWalkable)
                    newcurr = _currentNodo.NodosConection["Left"];

                LookNodo("Left");
            }
        }
        if (Input.GetKeyDown(Right))
        {
            if (_currentNodo.NodosConection.ContainsKey("Right"))
            {
                if (_currentNodo.NodosConection["Right"].isWalkable)
                    newcurr = _currentNodo.NodosConection["Right"];
                
                LookNodo("Right");

            }
        }
        
        _nodoPos = newcurr.transform;
        _currentNodo = newcurr;

                
        return _nodoPos;
    }

    private void LookNodo(string Dir)
    {
        if (Dir == "Up")
        {
            transform.rotation =  Quaternion.Euler(0,0,0);
        }
        if (Dir == "Down")
        {
            transform.rotation =  Quaternion.Euler(0,180,0);
        }
        if (Dir == "Left")
        {
            transform.rotation =  Quaternion.Euler(0,270,0);
        }
        if (Dir == "Right")
        {
            transform.rotation =  Quaternion.Euler(0,90,0);
        }
    }
}
