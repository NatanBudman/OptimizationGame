using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateManagerGameplay : MonoBehaviour
{
    
    [SerializeField] Shooter _shooter;
    [SerializeField] PlayerController _playerController;
     //private IUpdates[] Updates;
    void Start()
    {
       // UpdateManager.Instance.add(this)  ;
         Application.targetFrameRate = 60;
        //AddUpdate(new Shooter());
    }

 
    public void UpdateGameplay()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            GameObject projectile = Instantiate(_shooter.projectilePrefab, _shooter.projectileSpawnPoint.position, Quaternion.identity);

            Vector3 directionBullet = transform.forward;

            projectile.GetComponent<Rigidbody>().velocity = directionBullet * _shooter.projectileSpeed;
        }

        _playerController.MouseRotation();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        _playerController.rb.MovePosition(transform.position + direction * _playerController.moveSpeed * Time.fixedDeltaTime);
        /* var Lenght = Updates.Length;

         for (int i = 0; i < Lenght; i++)
         {
             Updates[i].GameplayUpdate();


         }
        */
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
