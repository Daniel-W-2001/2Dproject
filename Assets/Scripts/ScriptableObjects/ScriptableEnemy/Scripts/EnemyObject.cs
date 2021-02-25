using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class EnemyObject : ScriptableObject
{
    public int maxHealth = 100;
    
    public bool isFlipped = false;

    public int attackDamage;
    public float attackRange = 1f;

    public Vector3 attackOffset;
    public LayerMask attackMask;

}
