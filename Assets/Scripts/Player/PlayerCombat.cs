using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{

    [Header("Enemy Layers")]
    [SerializeField] private LayerMask enemyLayer;

    [Header("Attack Properties")]
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;

    [Header ("Sound Effects")]
    [SerializeField] private AudioSource attack1Sound;
    [SerializeField] private AudioSource attack2Sound;

    
    private bool isSecondAttack = false;
    private int damage = 1;

    private EnemyHealth enemyHealth;
    private Animator playerAnimator;



    private void Awake()
    {
        playerAnimator= GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F))
        {
            if (!isSecondAttack)
            {
                Attack1(true);
            }
            else
            {
                Attack1(false);
            }

        }
     
        
    }
    private void Attack1(bool isSecondAttack)
    {
        if(isSecondAttack)
        {
            playerAnimator.SetTrigger("SecondAttack");
            attack2Sound.Play();
        }
        else
        {
            playerAnimator.SetTrigger("Attack");  
        }
        IsEnemyInAttackRange();

        this.isSecondAttack = !this.isSecondAttack;

    }
    private bool IsEnemyInAttackRange()
    {

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        if (hitEnemy != null)
        {
            foreach (var enemy in hitEnemy)
            {
                enemyHealth = enemy.GetComponent<EnemyHealth>();
            }
        }
        else
        {
            return false;
        }

        return hitEnemy != null;
    }
    // Set this method in animation event to apply damage when we want
    private void DamageEnemy()
    {
        if (IsEnemyInAttackRange() && enemyHealth != null)
        {
            attack2Sound.Play();
            enemyHealth.TakeDamage(damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
