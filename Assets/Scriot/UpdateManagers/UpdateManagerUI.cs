using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerUI : MonoBehaviour
{
    //[SerializeField] ContadorDisparos _contadorDisparos;
    [SerializeField] private IUpdates[] Updates;
    
    void Start()
    {
       // UpdateManager.Instance.add(this);

        Updates = GetComponents<IUpdates>();
        
        //AddUpdate(new ContadorDisparos());
    }

    public void UpdateUI()
    {
/*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _contadorDisparos.disparos++;
            _contadorDisparos.ActualizarDisparos(_contadorDisparos.disparos);
        }
     */   
        var Lenght = Updates.Length;

        for (int i = 0; i < Lenght; i++)
        {
            Updates[i].UIUpdate();


        }
        
    }
    /*
    public void AddUpdate(IUpdates newUpdate)
    {
        int oldLength = Updates.Length;
        Array.Resize(ref Updates, oldLength + 1);
        Updates[oldLength] = newUpdate;
    }
    */
}
