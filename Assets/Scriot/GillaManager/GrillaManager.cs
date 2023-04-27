using System;
using UnityEditor;
using UnityEngine;

public class GrillaManager : MonoBehaviour
{
    private Grilla _grilla;
    
    public int _width;
    public int _height;


    public Transform GrillaStartPos;

    [Header("CustomGrilla")]
    [SerializeField] private bool isCustomGrilla;
    
    // Serializado 
    [SerializeField] bool isGrillaVisible;
    [SerializeField] Mesh GrillaMesh;
    [SerializeField] Material[] Material;


     void OnValidate()
    {
        if (isCustomGrilla)
        { 
            
        }
        else
        {
            
        }
    }

    void Start()
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
