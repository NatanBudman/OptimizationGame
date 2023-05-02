using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Life;
    private int _currentLife;


    public void Damage(int damage)
    {
        _currentLife -= damage;
    }
// comprobador de si esta muerto
    public bool isDeath()
    {
        return _currentLife <= 0;
    }

    public void RealDeath()
    {
        Debug.Log("Murio algo");
    }
}
