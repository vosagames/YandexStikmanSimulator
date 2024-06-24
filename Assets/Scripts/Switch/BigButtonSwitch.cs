using UnityEngine;

public class BigButtonSwitch : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioPress;
    [SerializeField] private GameObject _script;
    private void Awake()
    {
        _script.SetActive(false);
        _animator = GetComponent<Animator>();
    }
    public void PressButton()
    {
        _audioPress.Play();
        _animator.SetTrigger("Press");
        _script.SetActive(true);
    }
}
