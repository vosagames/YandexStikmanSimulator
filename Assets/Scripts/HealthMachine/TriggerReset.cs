using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class TriggerReset : MonoBehaviour
{
    [SerializeField] private GameObject HealthMachine;
    [SerializeField] private HealthMachineControl HMC;

    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthMachine.GetComponent<Animator>().SetFloat("speed", -1f);
            HealthMachine.GetComponent<Animator>().SetTrigger("OpenDoor");
            Player = other.gameObject;
            HMC.HealthPlayer();
            gameObject.SetActive(false);
        }
    }

}
