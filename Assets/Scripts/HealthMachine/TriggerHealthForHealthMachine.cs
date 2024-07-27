using UnityEngine;

public class TriggerHealthForHealthMachine : MonoBehaviour
{
    [SerializeField] private GameObject _triggerOpenDoorForHealthMachine;

    [SerializeField] private HealthMachineControl _healthMachineControl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() || other.GetComponent<PlayerControllerType2>() || other.GetComponent<Type3PlayerController>())
        {
            _triggerOpenDoorForHealthMachine.SetActive(false);
            if(FindObjectOfType<CameraRay>() != null )
            {
                Destroy( FindObjectOfType<CameraRay>() );
            }
            else
            {
                Debug.Log("Camera not find");
            }
            Destroy(other.gameObject, 1f);
            _healthMachineControl.CloseDoorHealthMachine();
            Invoke("TriggerFalse", 1f);
        }
    }

    private void TriggerFalse()
    {
        _healthMachineControl.HealthPlayer();
        gameObject.SetActive(false);
    }
}
