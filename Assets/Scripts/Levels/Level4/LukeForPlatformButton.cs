using UnityEngine;

public class LukeForPlatformButton : MonoBehaviour
{
    private bool isOpen;

    private int second;

    private void Start()
    {
        InvokeRepeating("OpenCloseControl", 0f, 1f);
    }

    private void FixedUpdate()
    {
        if(isOpen == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 75f), 10f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 70f), 10f * Time.deltaTime);
        }
    }

    private void OpenCloseControl()
    {
        second++;
        if(second == 4) 
        {
            isOpen = true;
        }
        if(second == 5) 
        {
            second = 0;
            isOpen = false;
        }
    }
}
