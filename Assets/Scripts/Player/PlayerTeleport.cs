using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject _currentDoor;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _currentDoor != null)
        {
            transform.position = _currentDoor.GetComponent<Doors>().GetNextRoomPosition().position;
            PlayRoomAudio();
        }
    }

    private void PlayRoomAudio()
    {
        
        if (_currentDoor.GetComponent<Doors>().GetRoomAudio() != null)
        {
            foreach (var sound in GameObject.Find("Player").GetComponents<AudioSource>())
            {
                sound.Pause();
            }
            _currentDoor.GetComponent<Doors>().GetRoomAudio().Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            _currentDoor= collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            _currentDoor = null;
        }
    }
}
