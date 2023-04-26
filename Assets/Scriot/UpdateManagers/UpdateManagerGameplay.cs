using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerGameplay : MonoBehaviour
{
    
    //[SerializeField] Shooter _shooter;
    //[SerializeField] PlayerController _playerController;
     private IUpdates[] Updates;
    void Start()
    {
       // UpdateManager.Instance.add(this)  ;
         Application.targetFrameRate = 60;
         
         Updates = GetComponents<IUpdates>();

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
