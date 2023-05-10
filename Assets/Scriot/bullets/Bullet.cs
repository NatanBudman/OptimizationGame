using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<int> _layerMasks;
    public Rigidbody _rb;

    #region ScriptableObject
    
        public BulletScriptableObject _bulletScriptableObject;

        private int _Speed => _bulletScriptableObject.Speed;
        public int _Damage => _bulletScriptableObject.Damage;
        private float _DisbaleTimer => _bulletScriptableObject.DisableTimer;

    #endregion
 
    
    
    private float currentTime;

    public BulletPool Pool;

    
    private void Update()
    {
        Movement();
        currentTime += Time.deltaTime;

        if (currentTime >= _DisbaleTimer)
        {
            // Vuelve al pool
            Pool.ReturnBulletToPool(this.gameObject);
            currentTime = 0;
        }
        
    }

    private void Movement()
    {
        Vector3 movement = transform.forward;

        movement = movement.normalized * _Speed * Time.deltaTime;

        _rb.MovePosition(transform.position + movement);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_layerMasks.Contains(collision.gameObject.layer))
        {
            HealthController heatlh = collision.collider.GetComponent<HealthController>();
            heatlh.Damage(_Damage);
            Debug.Log(heatlh._currentLife);
            currentTime = 0;
            Pool.ReturnBulletToPool(this.gameObject);
        }else if (!_layerMasks.Contains(collision.gameObject.layer) && collision.collider.gameObject != this.gameObject)
        {
            currentTime = 0;
            Pool.ReturnBulletToPool(this.gameObject);
        }
    }
}
