using UnityEngine;

public class ExitPowerControl : MonoBehaviour
{
    private void OnEnable() => FindObjectOfType<MovePlatform>().enabled = true;

    private void OnDisable() => FindObjectOfType<MovePlatform>().enabled = false;
}
