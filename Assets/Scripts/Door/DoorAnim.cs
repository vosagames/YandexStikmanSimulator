using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _footstep;
    [SerializeField] private AudioSource openDoor, closeDoor;

    public void OpenDoorAudio() => openDoor.Play();
    public void CloseDoorAudio() => closeDoor.Play();
    public void FootstepAudio() => _footstep[Random.Range(0, _footstep.Count)].Play();
}
