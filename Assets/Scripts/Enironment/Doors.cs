using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Transform nextRoomPosition;
    [SerializeField] private AudioSource nextRoomAudio;
   
    public Transform GetNextRoomPosition()
    {
        return nextRoomPosition;
    }
    public AudioSource GetRoomAudio()
    {
        return nextRoomAudio;
    }
}
