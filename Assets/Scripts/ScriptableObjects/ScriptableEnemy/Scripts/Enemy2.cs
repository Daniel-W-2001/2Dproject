using System.Collections;
using UnityEngine;

namespace ScriptableObjects.ScriptableEnemy.Scripts
{
    public class Enemy2 : MonoBehaviour
    {
        private GameObject thisGameObject;


        [Space] 
        public bool usedAfterDeath = false;
        public int destroyTime = 2;
        [Space]
        
        
        [Header("Enemy Part")]
        public EnemyObject scriptEnemy;
        private Animator animator;
        
        public Transform player2;

        private BoxCollider2D boxCollider2D;

        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthBar;
        public Canvas canvas;

        private bool isFlipped = false;

        public GameObject deathEffect;
        public GameObject effectPoint;
        private bool hasPlayed = false;
        [Space]
        
        [Header("Enemy Attack Part")] 
        
        private Vector3 attackOffset;
        private float attackRange;
        private LayerMask attackMask;
        private int attackDamage;
        [Space]
        
        // Enemy Looks
        private Sprite enemyHead;
        private Sprite enemyFace;
        private Sprite enemyHood;
        private Sprite enemyWeaponL;
        private Sprite enemyWristL;
        private Sprite enemyElbowL;
        private Sprite enemyShoulderL;
        private Sprite enemyWeaponR;
        private Sprite enemyWristR;
        private Sprite enemyElbowR;
        private Sprite enemyShoulderR;
        private Sprite enemyTorso;
        private Sprite enemyBootL;
        private Sprite enemyLegL;
        private Sprite enemyBootR;
        private Sprite enemyLegR;
        private Sprite enemyPelvis;

        [Header("EnemyLooks")]
        public GameObject enemyHead_object;
        public GameObject enemyFace_object;
        public GameObject enemyHood_object;
        public GameObject enemyWeaponL_object;
        public GameObject enemyWristL_object;
        public GameObject enemyElbowL_object;
        public GameObject enemyShoulderL_object;
        public GameObject enemyWeaponR_object;
        public GameObject enemyWristR_object;
        public GameObject enemyElbowR_object;
        public GameObject enemyShoulderR_object;
        public GameObject enemyTorso_object;
        public GameObject enemyBootL_object;
        public GameObject enemyLegL_object;
        public GameObject enemyBootR_object;
        public GameObject enemyLegR_object;
        public GameObject enemyPelvis_object;
        

    void Start()
        {
            SetEnemy();
            SetAttack();
            // It's Hardcoding time!
            SetObjects();
            SetSprites();
        }

    

    void SetObjects()
        {
            // Could probably get a loop to do this but this should work just fiiinnneee (Also i didn't find out how)
            enemyHead = scriptEnemy.enemyHead;
            enemyFace = scriptEnemy.enemyFace;
            enemyHood = scriptEnemy.enemyHood;
            enemyWeaponL = scriptEnemy.enemyWeaponL;
            enemyWristL = scriptEnemy.enemyWristL;
            enemyElbowL = scriptEnemy.enemyElbowL;
            enemyShoulderL = scriptEnemy.enemyShoulderL;
            enemyWeaponR = scriptEnemy.enemyWeaponR;
            enemyWristR = scriptEnemy.enemyWristR;
            enemyElbowR = scriptEnemy.enemyElbowR;
            enemyShoulderR = scriptEnemy.enemyShoulderR;
            enemyTorso = scriptEnemy.enemyTorso;
            enemyBootL = scriptEnemy.enemyBootL;
            enemyLegL = scriptEnemy.enemyLegL;
            enemyBootR = scriptEnemy.enemyBootR;
            enemyLegR = scriptEnemy.enemyLegR;
            enemyPelvis = scriptEnemy.enemyPelvis;
            SetSprites();
        }
        void SetSprites() 
        {
            // Could probably get a loop to do this but this should work just fiiinnneee (Also i didn't find out how)
            enemyHead_object.GetComponent<SpriteRenderer>().sprite = enemyHead;
            enemyFace_object.GetComponent<SpriteRenderer>().sprite = enemyFace;
            enemyHood_object.GetComponent<SpriteRenderer>().sprite = enemyHood;
            enemyWeaponL_object.GetComponent<SpriteRenderer>().sprite = enemyWeaponL;
            enemyWristL_object.GetComponent<SpriteRenderer>().sprite = enemyWristL;
            enemyElbowL_object.GetComponent<SpriteRenderer>().sprite = enemyElbowL;
            enemyShoulderL_object.GetComponent<SpriteRenderer>().sprite = enemyShoulderL;
            enemyWeaponR_object.GetComponent<SpriteRenderer>().sprite = enemyWeaponR;
            enemyWristR_object.GetComponent<SpriteRenderer>().sprite = enemyWristR;
            enemyElbowR_object.GetComponent<SpriteRenderer>().sprite = enemyElbowR;
            enemyShoulderR_object.GetComponent<SpriteRenderer>().sprite = enemyShoulderR;
            enemyTorso_object.GetComponent<SpriteRenderer>().sprite = enemyTorso;
            enemyBootL_object.GetComponent<SpriteRenderer>().sprite = enemyBootL;
            enemyLegL_object.GetComponent<SpriteRenderer>().sprite = enemyLegL;
            enemyBootR_object.GetComponent<SpriteRenderer>().sprite = enemyBootR;
            enemyLegR_object.GetComponent<SpriteRenderer>().sprite = enemyLegR;
            enemyPelvis_object.GetComponent<SpriteRenderer>().sprite = enemyPelvis;
        }
        
        void SetEnemy()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            // Enemy part
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            
            //animController = scriptEnemy.animController;
            //GetComponent<Animator>().runtimeAnimatorController = animController;
            animator = GetComponent<Animator>();
        
            currentHealth = scriptEnemy.maxHealth;
        
            isFlipped = scriptEnemy.isFlipped;
        }
        void SetAttack()
        {
            // Enemy Attack
            attackRange = scriptEnemy.attackRange;
            attackDamage = scriptEnemy.attackDamage;
            attackOffset = scriptEnemy.attackOffset;
            attackMask = scriptEnemy.attackMask;
        }
    
        public void Attack()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null)
            {
                colInfo.GetComponent<PlayerCombat>()?.TakeDamage(attackDamage);
            }
        }

        void OnTriggerStay2D(Collider2D hitBox)
        {
            if (hitBox.CompareTag("Player")){
                Rigidbody2D rb = hitBox.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    animator.SetBool("Radius", true);
                }
            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                animator.SetBool("Radius", false);
            }
        }

        // private void OnTriggerEnter2D(Collider2D hitBox)
        // {
        //     if (hitBox.CompareTag("TilemapHitbox") == boxCollider2D.isTrigger) 
        //     {
        //         Debug.Log("Blocked");
        //         var position = transform.position;
        //         if (isFlipped)
        //         {
        //             
        //             gameObject.transform.position = new Vector3(position.x - .1f, position.y);
        //         }
        //         else
        //         {
        //             gameObject.transform.position = new Vector3(transform.position.x + .1f, position.y);
        //         }
        //     }
        // }

        public void LookAtPlayer()
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player2.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player2.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }

        public void TakeDamage(int damage)
        {
            StartCoroutine(DamageEffect());
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //Play hurt aniamtion
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
        IEnumerator DamageEffect()
        {
            SetAllSpriteColours(Color.red);
            yield return new WaitForSeconds(.2f);
            SetAllSpriteColours(Color.white);
        }

        void SetAllSpriteColours(Color col)
        {
            foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.color = col;
            }
        }

        void Die()
        {
            canvas.enabled = false;
            Invoke("Disable", 2);

            //Die animation
            animator.SetBool("IsDead", true);

            //Disable enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            
            if (!usedAfterDeath)
            {
                StartCoroutine(Decay(destroyTime));
            }
        }

        void Disable()
        {
            if (!hasPlayed)
            {
                var effect = (GameObject)Instantiate(deathEffect, effectPoint.transform.position, Quaternion.identity);
                Destroy(effect, 2);
                hasPlayed = true;
            }
        }

                IEnumerator Decay(int time)
        {
            yield return new WaitForSeconds(destroyTime);
            // Debug.Log(gameObject.name + " was destroyed to save memory");
            Destroy(gameObject);
            // Kan være lurt å slette gameObject hvis det ikke skal brukes igjen
        }
    }
}