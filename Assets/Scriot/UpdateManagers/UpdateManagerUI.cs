using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerUI : MonoBehaviour
{
    //[SerializeField] ContadorDisparos _contadorDisparos;
    [SerializeField] private IUpdates[] Updates;
    private UpdateManager _manager;

    
    void Start()
    {
        _manager = FindObjectOfType<UpdateManager>();

        _manager.AddManagers(this.gameObject.GetComponent<UpdateManagerUI>());

        Updates = GetComponents<IUpdates>();
        
    }

    public void UpdateUI()
    {
        var Lenght = Updates.Length;

        for (int i = 0; i < Lenght; i++)
        {
            Updates[i].UIUpdate();
        }
        
    }
}
