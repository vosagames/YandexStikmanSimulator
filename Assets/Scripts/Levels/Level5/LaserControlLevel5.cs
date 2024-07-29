using UnityEngine;

public class LaserControlLevel5 : MonoBehaviour
{
    [SerializeField] private GameObject Laser1;
    [SerializeField] private GameObject Laser2;

    private void OnEnable()
    {
        Laser1.GetComponent<Laser>().Power = false;
        Laser2.GetComponent<Laser>().Power = true;
    }

    private void OnDisable()
    {
        Laser1.GetComponent<Laser>().Power = true;
        Laser2.GetComponent<Laser>().Power = false;
    }
}
