using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyObject : ScriptableObject
{
    // Enemy
    public AnimatorController animController;
    public int maxHealth = 100;
    public bool isFlipped = false;

    // Enemy Attack
    public int attackDamage;
    public float attackRange = 1f;
    public Vector3 attackOffset;
    public LayerMask attackMask;

    public Sprite[] sprites;

}
