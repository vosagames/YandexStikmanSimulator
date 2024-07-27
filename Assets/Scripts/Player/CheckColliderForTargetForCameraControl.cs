using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderForTargetForCameraControl : MonoBehaviour
{
    [SerializeField] private TargetForCameraControl _targetForCameraControl;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "NoUseCollider" && other.gameObject.tag != "Player" && other.gameObject.tag != "UseInput")
        {
            _targetForCameraControl.ResetPosition();
        }
    }
}
