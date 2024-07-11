using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerPlatform : MonoBehaviour
{
    [SerializeField] GameObject Script1, Script2;

    private void Awake()
    {
        Script1.SetActive(false);
        Script2.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject != null)
        {
            Script1.SetActive(true);
            Script2.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {

            Script2.SetActive(true);
            Script1.SetActive(false);

    }
}

