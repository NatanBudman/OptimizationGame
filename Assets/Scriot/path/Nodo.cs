using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public bool isWalkable = true;
    public Nodo[] Neighbor = new Nodo[4];
    private int index = 0;

    [SerializeField]private bool isCheckNeighbor = false;
    // Instance
    [Space(4)] [SerializeField] private GameObject InstanceObject;
    private GameObject ObjectCreate;
    [SerializeField] private Vector3 posCreateObject;

    public void CreateObject()
    {
        GameObject Intance = Instantiate(InstanceObject, posCreateObject, Quaternion.identity, transform);
        ObjectCreate = Intance;
    }

    public void DeleteObject()
    {
        DestroyImmediate(ObjectCreate);
    }

    Vector3[] directions = { Vector3.forward, -Vector3.forward, Vector3.left, Vector3.right };
    
    int _index = 0;

    public void GetNeighborNodes()
    {
         
            if (!isCheckNeighbor && isWalkable)
            {
                var lenght = directions.Length;
                
                for (int i = 0; i < lenght; i++)
                {
                    RaycastHit hit;
                    Ray ray = new Ray(transform.position, directions[i]);
               
                    if (Physics.Raycast(ray, out hit, 1.2f))
                    {
                        if (hit.collider != null)
                        {
                            if (hit.collider.gameObject.GetComponent<Nodo>() != null )
                            {
                                if (hit.collider.gameObject.GetComponent<Nodo>().isWalkable == true)
                                {
                                    _index++;
                                }
                            }
                        }
                      
                    }

                }
                
                Neighbor = new Nodo[_index];

                for (int j = 0; j < lenght; j++)
                {
                    RaycastHit hit2;
                    Ray ray2 = new Ray(transform.position, directions[j]);
                    
                    if (Physics.Raycast(ray2, out hit2, 1.2f))
                    {
                        if (hit2.collider != null)
                        {
                            if (hit2.collider.gameObject.GetComponent<Nodo>() != null )
                            {
                                if (hit2.collider.gameObject.GetComponent<Nodo>().isWalkable == true)
                                {
                                    Neighbor[index] = hit2.collider.gameObject.GetComponent<Nodo>();
                                    index++;
                                }
                            }
                        }
                    }
                   
                }
                
                isCheckNeighbor = true;

            }
            


        
    }
}
