
using UnityEngine;

public class ObjectLookCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Update()
    {
        transform.LookAt(target);
    }
    public void ActiveFalse() => gameObject.SetActive(false);
}
