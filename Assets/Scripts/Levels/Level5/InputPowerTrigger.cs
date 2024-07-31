using UnityEngine;

public class InputPowerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject script1;
    [SerializeField] private GameObject script2;

    public void OnTriggerEnter(Collider other)
    {
        script1.SetActive(true);
        script2.SetActive(false);
    }
    public void OnTriggerExit(Collider other)
    {
        script1.SetActive(false);
        script2.SetActive(true);
    }
}
