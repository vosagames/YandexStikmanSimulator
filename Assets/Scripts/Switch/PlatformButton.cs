using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField] Transform Button;
    [SerializeField] GameObject Script1, Script2;

    private bool bpress = false;

    private void Awake()
    {
        Script1.SetActive(false);
        Script2.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && collision.gameObject.CompareTag("GrabBody"))
        {
            if (bpress == false)
            {
                Vector3 press = new Vector3(Button.localScale.x, Button.localScale.y, 4f);
                Button.transform.localScale = press;
                Script1.SetActive(true);
                Script2.SetActive(false);
                bpress = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (bpress == true && other.gameObject.CompareTag("GrabBody"))
        {
            Vector3 unpress = new Vector3(Button.localScale.x, Button.localScale.y, 8f);
            Button.transform.localScale = unpress;
            Script2.SetActive(true);
            Script1.SetActive(false);
            bpress = false;
        }
    }
}
