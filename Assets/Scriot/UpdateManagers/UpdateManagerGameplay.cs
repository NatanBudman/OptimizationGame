using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerGameplay : MonoBehaviour
{
    private IUpdates[] Updates;
     
     [SerializeField]private UpdateManager _manager;
    void Start()
    {
        _manager = FindObjectOfType<UpdateManager>();
         Updates = GetComponents<IUpdates>();
         AddManager();
    }

    public void AddManager()
    {
        if (_manager == null)
        {
            _manager = FindObjectOfType<UpdateManager>();
        }
        UpdateManagerGameplay update = gameObject.GetComponent<UpdateManagerGameplay>();
        _manager.AddManagers(update);
    }

    public void UpdateGameplay()
    {
   
         var Lenght = Updates.Length;

         for (int i = 0; i < Lenght; i++)
         {
             Updates[i].GameplayUpdate();
         }
        
    }
  
}
