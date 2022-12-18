using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private void Start()
    {
        
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth  = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(10);
        }
    }
}
