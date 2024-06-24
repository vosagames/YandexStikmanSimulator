
using UnityEngine;

public class BladeTrapStop : MonoBehaviour
{
    void Start()
    {
        var objects = Object.FindObjectsOfType<BladeTrap>();
        for (int i = 0; i < objects.Length; i++) 
        {
            objects[i].TrapEnable = false;
        }
    }

}
