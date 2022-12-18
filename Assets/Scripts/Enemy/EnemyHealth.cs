using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    public bool IsAlive { get; private set; }

    private int enemyCurrentHealth;
    [SerializeField] private int enemyMaxHealth;

    [SerializeField] private Behaviour[] components;
    private Animator enemyAnimator;

    
   

    private void Awake()
    {
        IsAlive = true;
        enemyCurrentHealth = enemyMaxHealth;
        enemyAnimator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        CheckIfAlive();
        if (IsAlive)
        {
            enemyAnimator.SetTrigger("TakeDamage");
        }
    }

    public void CheckIfAlive()
    {
        if(enemyCurrentHealth <= 0)
        {
            IsAlive= false;
            
            this.enabled= false;
            

            enemyAnimator.SetBool("isAlive", IsAlive);
        }
    }

    //set this method in animation event
    public void DestroyAshes()
    {
        foreach (Behaviour comp in components)
        {
            comp.enabled = false;
        }
        gameObject.SetActive(false);
    }
}
