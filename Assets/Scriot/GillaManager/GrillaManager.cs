using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrillaManager : MonoBehaviour
{
    // InicializeGrilla
    public Grilla _grilla;
    public int _width;
    public int _height;
    public Transform GrillaStartPos;
    
    // Grilla Created
    [SerializeField] private List<Nodo[]> grillas = new List<Nodo[]>(50);

    private int indexGrillas = 0;

    
    
    
    //Custom Grilla
    [Header("CustomGrilla")]
    public bool isCustomGrilla;
    
    // Serializado 
    public bool isGrillaVisible;
    public Mesh GrillaMesh;
    public Material[] Material;

    public void create()
     {
         _grilla = new Grilla(_width,_height,GrillaStartPos);
         
         if (isCustomGrilla)
         {
             _grilla.CreateGrilla(GrillaMesh,Material,isGrillaVisible);
         }
         else
         {
             _grilla.CreateGrilla();

         }
         grillas.Add(_grilla.GetGrilla());

         Debug.Log(grillas.Count);
     }

     public void DeleteGrilla()
     {
         RemoveGrilla();
     }

     private void RemoveGrilla()
     {
         
         var _objetc = grillas[indexGrillas][0].gameObject.transform.parent.gameObject;
         DestroyImmediate(_objetc); 
         grillas.Remove(grillas[indexGrillas]);

     }

    
}
