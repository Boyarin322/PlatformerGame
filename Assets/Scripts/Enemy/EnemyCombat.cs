using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header ("Attack Properties")]
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header ("Box Collider")]
    [SerializeField] private BoxCollider2D boxCollider;

    private float cooldownTimer = Mathf.Infinity;
   
    private RaycastHit2D enemyVision;
    private Animator enemyAnimator;
    private PlayerHealth playerHealth;
    

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (IsPlayerInSight())
        {
            if (cooldownTimer >= attackSpeed)
            {
                //DamagePlayer
                cooldownTimer= 0;
                enemyAnimator.SetTrigger("Attack");
               
            }
        }
    }
    private bool IsPlayerInSight()
    {
        enemyVision = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * (transform.localScale.x / 3)* colliderDistance, 
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y), 0, 
            Vector2.right, 0, playerLayer);

        if(enemyVision.collider !=null)
        {
            playerHealth = enemyVision.transform.GetComponent<PlayerHealth>();
        }

        return enemyVision.collider != null; 
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * (transform.localScale.x / 3)* colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y));
    }

    // Set this method in animation event
    private void DamagePlayer()
    {
        
        if (IsPlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
} 
