using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Bullets",fileName = "Bullet") ]
public class BulletScriptableObject : ScriptableObject
{
    public int Speed;
    public int Damage;
    public float DisableTimer;
}
