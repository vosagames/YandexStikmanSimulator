using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForCameraControl : MonoBehaviour
{
    [SerializeField] private Transform _strartPositionObject;
    [SerializeField] private Transform _endPositionObject;

    private bool touchWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "NoUseCollider" && other.gameObject.tag != "Player" && other.gameObject.tag != "UseInput")
        {
            touchWall = true;
            NewPosition();
        }
    }
    public void ResetPosition()
    {
        touchWall = false;
        NewPosition();
    }

    private void NewPosition()
    {
        if (touchWall == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.position = _endPositionObject.position;
        }
        else
        {
            gameObject.transform.position = _strartPositionObject.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
