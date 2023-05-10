using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public bool isWalkable = true;
    [SerializeField]private bool isCheckNeighbor = false;

// guardo los nodos de cada direccion
    public Dictionary<string, Nodo> NodosConection;

    Vector3[] directions = { Vector3.forward, -Vector3.forward, Vector3.left, Vector3.right };
    
    public void GetNeighborNodes()
    {
         
            if (!isCheckNeighbor && isWalkable)
            {
                NodosConection = new Dictionary<string, Nodo>();
                
                var lenght = directions.Length;
                
                for (int j = 0; j < lenght; j++)
                {
                    RaycastHit hit2;
                    Ray ray2 = new Ray(transform.position, directions[j]);
                    
                    if (Physics.Raycast(ray2, out hit2, 1 + (transform.localScale.x / 2 )))
                    {
                        if (hit2.collider != null)
                        {
                            if (hit2.collider.gameObject.GetComponent<Nodo>() != null )
                            {
                                if (hit2.collider.gameObject.GetComponent<Nodo>().isWalkable == true)
                                {
                                    Nodo coll = hit2.collider.gameObject.GetComponent<Nodo>();
                                    switch (j)
                                    {
                                        case 0: NodosConection.Add("Up",coll);
                                            break;
                                        case 1: NodosConection.Add("Down",coll);
                                            break;
                                        case 2: NodosConection.Add("Left",coll);
                                            break;
                                        case 3: NodosConection.Add("Right",coll);
                                            break;
                                    }

                                }
                            }
                        }
                    }
                   
                }
                
                isCheckNeighbor = true;

            }
            


        
    }
}
