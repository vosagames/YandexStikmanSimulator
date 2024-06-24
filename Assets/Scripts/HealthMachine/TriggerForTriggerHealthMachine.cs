using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTriggerHealthMachine : MonoBehaviour
{
    [SerializeField] private GameObject TriggerStartHealthMachine;
    [SerializeField] private GameObject VirtualCamera;
    [SerializeField] private Animator HealthMachine;


    private void OnTriggerExit(Collider other)
    {
        TriggerStartHealthMachine.SetActive(true);
        VirtualCamera.SetActive(false);
        gameObject.SetActive(false);
        HealthMachine.SetFloat("speed", -1f);
        HealthMachine.SetTrigger("OpenDoor");
    }
}
