using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using YG;

public class HealthMachineControl : MonoBehaviour
{
    [SerializeField] private TriggerReset tReset;

    [SerializeField] private Animator HealthMachine;

    [SerializeField] private Transform SpawnPos;

    [SerializeField] private GameObject newPlayer;
    [SerializeField] private GameObject newRay;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject TriggerForStart;
    [SerializeField] private GameObject TriggerStart;
    [SerializeField] private GameObject InputE;

    private void Awake()
    {
        HealthMachine = GetComponent<Animator>();
        InputE = FindObjectOfType<ObjectLookCamera>().gameObject;
    }

    public void HealthPlayer()
    {
        player = tReset.Player;
        Invoke("ResetPlayer", 2f);
        Invoke("DestroyPlayer", 0.3f);
    }
    private void ResetPlayer()
    {
        TriggerStart.SetActive(false);
        TriggerForStart.SetActive(true);
        InputE.SetActive(true);
        Health = 100;
        Save();
        Instantiate(newRay, SpawnPos.position, transform.rotation);
        Instantiate(newPlayer, SpawnPos.position, transform.rotation);
        Invoke("OpenDoor", 1f);
    }
    private void DestroyPlayer() => Destroy(player);
    private void OpenDoor()
    {
        HealthMachine.SetFloat("speed", 1f);
        HealthMachine.SetTrigger("OpenDoor");
    }
    public void Save()
    {
        YandexGame.savesData.Health = Health;
        YandexGame.SaveProgress();
    }
}

