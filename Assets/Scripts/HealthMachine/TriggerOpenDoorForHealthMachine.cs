using UnityEngine;

public class TriggerOpenDoorForHealthMachine : MonoBehaviour
{
    [SerializeField] private HealthMachineControl _healthMachineControl;
    [SerializeField] private GameObject _virtualCameraForHealthMachine;
    [SerializeField] private GameObject _triggerHealthMachine;

    private void Awake()
    {
        _virtualCameraForHealthMachine.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() || other.GetComponent<PlayerControllerType2>() || other.GetComponent<Type3PlayerController>())
        {
            _virtualCameraForHealthMachine.SetActive(true);
            _healthMachineControl.OpenDoorHealthMachine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() || other.GetComponent<PlayerControllerType2>() || other.GetComponent<Type3PlayerController>())
        {
            _virtualCameraForHealthMachine.SetActive(false);
            _healthMachineControl.CloseDoorHealthMachine();
            _triggerHealthMachine.SetActive(true);
        }
    }
}
