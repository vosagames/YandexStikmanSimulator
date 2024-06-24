using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartHealthMachine : MonoBehaviour
{
    [SerializeField] private GameObject VirtualCam;
    [SerializeField] private GameObject HealthMachine;
    [SerializeField] private GameObject ResetTrigger;

    private void Awake()
    {
        VirtualCam.SetActive(false);
        ResetTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VirtualCam.SetActive(true);
            ResetTrigger.SetActive(true);
            HealthMachine.GetComponent<Animator>().SetFloat("speed", 1f);
            HealthMachine.GetComponent<Animator>().SetTrigger("OpenDoor");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VirtualCam.SetActive(false);
            ResetTrigger.SetActive(false);
            HealthMachine.GetComponent<Animator>().SetFloat("speed", -1f);
            HealthMachine.GetComponent<Animator>().SetTrigger("OpenDoor");
        }
    }

}
