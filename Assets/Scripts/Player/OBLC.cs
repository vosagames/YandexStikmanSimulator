using UnityEngine;

public class OBLC : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Start()
    {
        _target = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(_target);
    }
}
