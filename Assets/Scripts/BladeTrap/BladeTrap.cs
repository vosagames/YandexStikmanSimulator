using UnityEngine;

public class BladeTrap : MonoBehaviour
{
    [SerializeField] private Transform _joint;

    [SerializeField] private AudioSource _bladeTrapAudio;

    [Range(-100f, 100f), SerializeField] private float _speed = 1f;

    public bool TrapEnable = true;

    private void FixedUpdate()
    {
        if (TrapEnable == true)
        {
            _joint.transform.Rotate(_speed, 0f, 0f);
        }
        else
        {
            _bladeTrapAudio.Stop();
            Debug.Log("Power  off");
            for (int i = 0; i < _joint.childCount; i++)
            {
                Transform Child = _joint.GetChild(i);
                Child.transform.tag = "Untagged";
            }
        }
    }
}
