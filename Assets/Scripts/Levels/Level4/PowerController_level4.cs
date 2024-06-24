using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController_level4 : MonoBehaviour
{
    [SerializeField] private List<ObjectControlUpAndDown> ObjectUpAndDown;

    private void OnEnable()
    {
        for (int i = 0; i < ObjectUpAndDown.Count; i++) 
        {
            ObjectUpAndDown[i].Power = true;
        }
    }

}
