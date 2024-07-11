using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ClueControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> _clue = new List<GameObject>();

    private float reload;
    private int numberClue;

    private void Start()
    {
        for (int i = 0; i < _clue.Count; i++) 
        {
            Debug.Log("123");
        }
    }
    public void ClueShow()
    {

    }

}
