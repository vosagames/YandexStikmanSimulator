using UnityEngine;
using static GameManager;

public class VoiceDictorSwap : MonoBehaviour
{
    [SerializeField] private VoiceDictorControl _control;

    private void Start()
    {
        switch (NumberLevel)
        {
            case 1:
                {
                    Invoke("VoiceDictorPlay", 8.5f);
                }
                break;
            case 6:
                {
                    Invoke("VoiceDictorPlay", 6f);
                }
                break;
        }
    }
    private void VoiceDictorPlay()
    {
        _control = GetComponent<VoiceDictorControl>();
        _control.voiceControl();
    }

}
