using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Life = 1;
    public int _currentLife;

    private void Start()
    {
        _currentLife = Life;
    }

    public void Damage(int damage)
    {
        _currentLife -= damage;
    }
// comprobador de si esta muerto
    public bool isDeath()
    {
        return _currentLife <= 0;
    }

    public void Revive()
    {
        _currentLife = Life;
    }
}
