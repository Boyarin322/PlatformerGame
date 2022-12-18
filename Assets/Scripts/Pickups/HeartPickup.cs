using UnityEngine;

public class HeartPickup : MonoBehaviour
{
   
    private int healValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Heal(healValue);
            gameObject.SetActive(false);
        }
    }

}
