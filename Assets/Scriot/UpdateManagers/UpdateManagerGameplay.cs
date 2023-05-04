using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerGameplay : MonoBehaviour
{
    
    //[SerializeField] Shooter _shooter;
    //[SerializeField] PlayerController _playerController;
     private IUpdates[] Updates;
     
     private UpdateManager _manager;
    void Start()
    {
        _manager = FindObjectOfType<UpdateManager>();
         Updates = GetComponents<IUpdates>();
         Debug.Log(_manager);
         _manager.AddManagers(this.gameObject.GetComponent<UpdateManagerGameplay>());
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
