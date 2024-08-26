using UnityEngine;

public class VoiceDictorTrigger : MonoBehaviour
{
    [SerializeField] private VoiceDictorControl _control;

    private void Start() => _control = FindObjectOfType<VoiceDictorControl>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() || other.gameObject.GetComponent<PlayerControllerType2>() || other.gameObject.GetComponent<Type3PlayerController>())
        {
            _control.voiceControl();
            Destroy(gameObject);
        }
    }
}
