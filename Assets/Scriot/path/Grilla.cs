using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grilla
{
    private int _width;
    private int _height;

    private Transform startPos;


    public Nodo[] grilla; 
    
    private int grillasIndex; 

    public Grilla(int width, int height, Transform start)
    {
        _width = width;
        _height = height;

        startPos = start;
    }

    public void CreateGrilla()
    {
        grilla = new Nodo[_width * _height];
        grillasIndex = 0;
        
        // Creo el padre de la grilla
        GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Cube);
        parent.name = "Grilla";
        parent.transform.SetParent(parent.transform);
        parent.transform.position = startPos.position;

        // creo la grilla
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                Vector3 position = new Vector3(startPos.position.x + x, 0, startPos.position.z + z);
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitive.AddComponent<Nodo>();
                
                
                grilla[grillasIndex] = primitive.GetComponent<Nodo>();
                grillasIndex++;
                
                primitive.transform.SetParent(parent.transform);
                primitive.transform.position = position;
            }
        }
        
    }
    

    public void CreateGrilla(Mesh mesh,Material[] materials, bool isVisible)
    {
        grilla = new Nodo[_width * _height];
        grillasIndex = 0;
        
        // Creo el padre de la grilla
        GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Cube);
        parent.name = "Grilla";
        parent.transform.SetParent(parent.transform);
        parent.transform.position = startPos.position;
        
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
//                    primitive.GetComponent<MeshRenderer>().materials = null;

                }

                     
                grilla[grillasIndex] = primitive.GetComponent<Nodo>();
                grillasIndex++;

                //add positions
                         
                primitive.transform.SetParent(parent.transform);
                primitive.transform.position = position;
            }
        }
    }

    public Nodo[] GetGrilla()
    {
        var _gri = grilla;
        return _gri;
    }

   

}
