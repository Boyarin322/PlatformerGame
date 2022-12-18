using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentDoor;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentDoor != null)
        {
            transform.position = currentDoor.GetComponent<Doors>().GetNextRoomPosition().position;
            PlayRoomAudio();
        }
    }

    private void PlayRoomAudio()
    {
        
        if (currentDoor.GetComponent<Doors>().GetRoomAudio() != null)
        {
            foreach (var sound in GameObject.Find("Player").GetComponents<AudioSource>())
            {
                sound.Pause();
            }
            currentDoor.GetComponent<Doors>().GetRoomAudio().Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            currentDoor= collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            currentDoor = null;
        }
    }
}
