using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    private void Start()
    {
        
        _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyHealth  = collision.gameObject.GetComponent<EnemyHealth>();
            _enemyHealth.TakeDamage(10);
        }
    }
}
