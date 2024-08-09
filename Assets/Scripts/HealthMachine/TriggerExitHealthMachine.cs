using UnityEngine;

public class TriggerExitHealthMachine : MonoBehaviour
{
    [SerializeField] private GameObject _triggerOpenDoorHealthMachine;
    [SerializeField] private GameObject _camera;
    [SerializeField] private HealthMachineControl _healthMachineControl;
    [SerializeField] private GameObject _healthMachineTrigger;

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() || other.GetComponent<PlayerControllerType2>() || other.GetComponent<Type3PlayerController>())
        {
            _triggerOpenDoorHealthMachine.SetActive(true);
            _healthMachineTrigger.SetActive(true);
            _camera.SetActive(false);
            _healthMachineControl.CloseDoorHealthMachine();
            gameObject.SetActive(false);
        }
    }
}
