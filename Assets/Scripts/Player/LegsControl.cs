using UnityEngine;

public class LegsControl : MonoBehaviour
{
    [SerializeField] private Transform _SpawnPos1;
    [SerializeField] private Transform _SpawnPos2;
    [SerializeField] Transform _playerRotation;
    [SerializeField] private DamageControl _damageControl;

    [SerializeField] private GameObject _DestroyObj;
    [SerializeField] private GameObject _SpawnObj1;
    [SerializeField] private GameObject _SpawnObj2;
    [SerializeField] private GameObject _ray;

    private void Start()
    {
        _damageControl = GameObject.FindAnyObjectByType<DamageControl>();
        _ray = FindObjectOfType<CameraRay>().gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            DamageBody();
        }
    }
    public void DamageBody()
    {
        Debug.Log("коснулся");
        Destroy(_ray);
        Instantiate(_SpawnObj1, _SpawnPos1.position, Quaternion.Euler(_playerRotation.rotation.eulerAngles));
        Instantiate(_SpawnObj2, _SpawnPos2.position, Quaternion.Euler(Quaternion.identity.x, _playerRotation.rotation.eulerAngles.y, Quaternion.identity.z));
        _damageControl.Damage(20);
        Destroy(_DestroyObj);
    }
}
