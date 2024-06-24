using UnityEngine;

public class TwoButtonsController : MonoBehaviour
{
    public bool ButtonOne, ButtonTwo;

    [SerializeField] private GameObject DoorUp, DoorDown;

    public void ButtonsPressed()
    {
        if(ButtonOne == true && ButtonTwo == true)
        {
            DoorUp.SetActive(true);
            DoorDown.SetActive(false);
        }
        else
        {
            DoorUp.SetActive(false);
            DoorDown.SetActive(true);
        }
    }

}
