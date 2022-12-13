using UnityEngine;

public class HeartPickup : MonoBehaviour
{
   
    private int _healValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Heal(_healValue);
            gameObject.SetActive(false);
        }
    }

}
