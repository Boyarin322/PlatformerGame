using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRange;
    [SerializeField] private AudioSource _attack1Sound;
    [SerializeField] private AudioSource _attack2Sound;

    private Animator _playerAnimator;
    private bool _isSecondAttack = false;
    private int _damage = 1;
    private EnemyHealth _enemyHealth;
    
    

    private void Awake()
    {
        _playerAnimator= GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F))
        {
            if (!_isSecondAttack)
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
            _playerAnimator.SetTrigger("SecondAttack");
            _attack2Sound.Play();
        }
        else
        {
            _playerAnimator.SetTrigger("Attack");
            
        }
        IsEnemyInAttackRange();
        

        
       
        _isSecondAttack = !_isSecondAttack;

    }
    private bool IsEnemyInAttackRange()
    {
        Collider2D[] _hitEnemy = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        if (_hitEnemy != null)
        {
            foreach (var enemy in _hitEnemy)
            {
                _enemyHealth = enemy.GetComponent<EnemyHealth>();
            }
        }
        return _hitEnemy != null;
    }
    // Set this method in animation event
    private void DamageEnemy()
    {
        if (IsEnemyInAttackRange())
        {
            _attack2Sound.Play();
            _enemyHealth.TakeDamage(_damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

}
