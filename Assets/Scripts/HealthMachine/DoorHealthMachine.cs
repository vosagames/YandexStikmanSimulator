using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] GameObject doorCol;

    public void DoorFalse() => doorCol.SetActive(false);
    public void DoorTrue() => doorCol.SetActive(true);
}
