using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject objectDoor, animationDoor;

    private void Awake()
    {
        animationDoor.SetActive(false);
    }

    public void OpenDoor()
    {
        objectDoor.SetActive(false);
        animationDoor.SetActive(true);
        Invoke("NextLevel", 6f);
        var obj = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i<obj.Length; i++)
        {
            Destroy(obj[i]);
        }
    }

    private void NextLevel()
    {
        NumberLevel++;
        SceneManager.LoadScene(NumberLevel);
    }
}
