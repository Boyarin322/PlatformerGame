using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Transform _nextRoomPosition;
    [SerializeField] private AudioSource _nextRoomAudio;
   
    public Transform GetNextRoomPosition()
    {
        return _nextRoomPosition;
    }
    public AudioSource GetRoomAudio()
    {
        return _nextRoomAudio;
    }
}
