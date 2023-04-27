using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grilla
{
    private int _width;
    private int _height;



    private Transform startPos;

    public Grilla(int width, int height, Transform start)
    {
        _width = width;
        _height = height;

        startPos = start;
    }

    public void CreateGrilla()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                Vector3 position = new Vector3(startPos.position.x + x, 0, startPos.position.z + z);
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitive.AddComponent<Nodo>();
                primitive.transform.SetParent(startPos);
                primitive.transform.position = position;
            }
        }
    }
    public void CreateGrilla(Mesh mesh,Material[] materials, bool isVisible)
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                Vector3 position = new Vector3(startPos.position.x + x , 0, startPos.position.z + z );
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                //add componetns
                primitive.AddComponent<Nodo>();
                
                //add Renders
                if (isVisible)
                {
                    primitive.GetComponent<MeshFilter>().mesh = mesh;
                    primitive.GetComponent<MeshRenderer>().materials = materials;
                }
                else
                {
                    primitive.GetComponent<MeshFilter>().mesh = null;
                    primitive.GetComponent<MeshRenderer>().materials = null;

                }


                //add positions
                primitive.transform.SetParent(startPos);
                primitive.transform.position = position;
            }
        }
    }

}
