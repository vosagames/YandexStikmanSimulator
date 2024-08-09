using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    [SerializeField] private GameObject script1, script2;
    private void Awake()
    {
        script1.SetActive(false);
        script2.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            script1.SetActive(true);
            script2.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            script2.SetActive(true);
            script1.SetActive(false);
        }
    }

}
