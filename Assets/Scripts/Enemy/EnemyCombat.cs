using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header ("Attack Properties")]
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _range;
    [SerializeField] private float _colliderDistance;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("Enemy Box Collider")]
    [SerializeField] private BoxCollider2D _boxCollider;

    private float _cooldownTimer = Mathf.Infinity;
   
    private RaycastHit2D _enemyVision;
    private Animator _enemyAnimator;
    private PlayerHealth _playerHealth;


    private void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        if (IsPlayerInSight())
        {
            if (_cooldownTimer >= _attackSpeed)
            {
                //DamagePlayer
                _cooldownTimer= 0;
                _enemyAnimator.SetTrigger("Attack");
               
            }
        }
    }
    private bool IsPlayerInSight()
    {
        _enemyVision = Physics2D.BoxCast(_boxCollider.bounds.center + transform.right * _range * (transform.localScale.x / 3)* _colliderDistance, 
            new Vector2(_boxCollider.bounds.size.x * _range, _boxCollider.bounds.size.y), 0, 
            Vector2.right, 0, _playerLayer);
        if(_enemyVision.collider !=null)
        {
            _playerHealth = _enemyVision.transform.GetComponent<PlayerHealth>();
        }

        return _enemyVision.collider != null; 
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_boxCollider.bounds.center + transform.right * _range * (transform.localScale.x / 3)* _colliderDistance,
            new Vector2(_boxCollider.bounds.size.x * _range, _boxCollider.bounds.size.y));
    }

    // Set this method in animation event
    private void DamagePlayer()
    {
        
        if (IsPlayerInSight())
        {
            _playerHealth.TakeDamage(_damage);
        }
    }
} 
