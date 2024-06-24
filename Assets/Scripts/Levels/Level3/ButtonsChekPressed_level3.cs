using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonsChekPressed_level3 : MonoBehaviour
{
    [SerializeField] private bool Button;
    [SerializeField] private bool Unpress;
    public GameObject tbc;

    void OnEnable()
    {
        if (Unpress == false)
        {
            if (Button == true)
            {
                tbc.GetComponent<TwoButtonsController>().ButtonOne = true;
                tbc.GetComponent<TwoButtonsController>().ButtonsPressed();
            }
            if (Button == false)
            {
                tbc.GetComponent<TwoButtonsController>().ButtonTwo = true;
                tbc.GetComponent<TwoButtonsController>().ButtonsPressed();
            }
        }
        if (Unpress == true)
        {
            if (Button == true)
            {
                tbc.GetComponent<TwoButtonsController>().ButtonOne = false;
                tbc.GetComponent<TwoButtonsController>().ButtonsPressed();
            }
            if (Button == false)
            {
                tbc.GetComponent<TwoButtonsController>().ButtonTwo = false;
                tbc.GetComponent<TwoButtonsController>().ButtonsPressed();
            }
        }
    }
}
