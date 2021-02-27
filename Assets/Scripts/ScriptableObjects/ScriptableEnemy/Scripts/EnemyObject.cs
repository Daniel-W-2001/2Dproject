using UnityEditor.Animations;
using UnityEngine;

namespace ScriptableObjects.ScriptableEnemy.Scripts
{
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

        [Space,Space,Space]
        public Sprite enemyHead;
        public Sprite enemyFace;
        public Sprite enemyHood;
        public Sprite enemyWeaponL;
        public Sprite enemyWristL;
        public Sprite enemyElbowL;
        public Sprite enemyShoulderL;
        public Sprite enemyWeaponR;
        public Sprite enemyWristR;
        public Sprite enemyElbowR;
        public Sprite enemyShoulderR;
        public Sprite enemyTorso;
        public Sprite enemyBootL;
        public Sprite enemyLegL;
        public Sprite enemyBootR;
        public Sprite enemyLegR;
        public Sprite enemyPelvis;

    }
}
