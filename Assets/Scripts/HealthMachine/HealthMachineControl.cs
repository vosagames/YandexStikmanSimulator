using UnityEngine;
using static GameManager;
using YG;

public class HealthMachineControl : MonoBehaviour
{
    [SerializeField] private Animator _animatorHealthMachine;

    [SerializeField] private Transform _spawnPlayerPosition;

    [SerializeField] private GameObject _newPlayer;
    [SerializeField] private GameObject _newRay;
    [SerializeField] private GameObject _triggerExit;

    [SerializeField] AudioSource _doorSound;

    private void Start()
    {
        _animatorHealthMachine = GetComponent<Animator>();
    }

    public void OpenDoorHealthMachine()
    {
        _animatorHealthMachine.SetFloat("speed", 1f);
        _animatorHealthMachine.SetTrigger("OpenDoor");
        _doorSound.Play();
    }
    public void CloseDoorHealthMachine()
    {
        _animatorHealthMachine.SetFloat("speed", -1f);
        _animatorHealthMachine.SetTrigger("OpenDoor");
        _doorSound.Play();
    }
    public void HealthPlayer()
    {
        Health = 100;
        YandexGame.savesData.Health = Health;
        YandexGame.SaveProgress();
        Invoke("CreateNewPlayer", 0.5f);
    }
    private void CreateNewPlayer()
    {
        Instantiate(_newRay, transform.position, Quaternion.identity);
        Instantiate(_newPlayer, _spawnPlayerPosition.position, Quaternion.identity);
        _triggerExit.SetActive(true);
        OpenDoorHealthMachine();
    }

}
