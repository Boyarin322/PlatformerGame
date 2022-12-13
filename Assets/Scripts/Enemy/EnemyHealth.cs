using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    public bool IsAlive { get; private set; }
    private int _enemyCurrentHealth;
    [SerializeField] private int _enemyMaxHealth;

    [SerializeField] private Behaviour[] _components;

    private Animator _enemyAnimator;
   

    private void Awake()
    {
         IsAlive = true;
        _enemyCurrentHealth = _enemyMaxHealth;
        _enemyAnimator = GetComponent<Animator>();
    }
    public void TakeDamage(int _damage)
    {
        _enemyCurrentHealth -= _damage;
        CheckIfAlive();
        if (IsAlive)
        {
            _enemyAnimator.SetTrigger("TakeDamage");
        }
    }

    public void CheckIfAlive()
    {
        if(_enemyCurrentHealth <= 0)
        {
            IsAlive= false;
            
            this.enabled= false;
            

            _enemyAnimator.SetBool("isAlive", IsAlive);
        }
    }

    //set this method in animation event
    public void DestroyAshes()
    {
        foreach (Behaviour comp in _components)
        {
            comp.enabled = false;
        }
        gameObject.SetActive(false);
    }
}
