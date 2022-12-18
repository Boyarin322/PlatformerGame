using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    
    private readonly int coinValue = 1;
   

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerItems>().AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
   
}
