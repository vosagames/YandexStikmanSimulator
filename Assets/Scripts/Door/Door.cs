using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;
using YG;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject objectDoor, animationDoor;
    [SerializeField] private GameObject button;
    [SerializeField] private TimerControl timer;

    private void Awake()
    {
        animationDoor.SetActive(false);
        timer = FindObjectOfType<TimerControl>();
    }

    public void OpenDoor()
    {
        GameObject _UIcontrol = FindObjectOfType<UIcontrol>().gameObject;
        _UIcontrol.GetComponent<UIcontrol>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        objectDoor.SetActive(false);
        animationDoor.SetActive(true);
        Invoke("ShowButtonNextLevel", 6f);
        var obj = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i<obj.Length; i++)
        {
            Destroy(obj[i]);
        }
        
    }

    private void ShowButtonNextLevel()
    {
        button.SetActive(true);
    }
    public void NextLevel()
    {
        NumberLevel++;
        Save();
        SceneManager.LoadScene(NumberLevel);
    }
 
    public void Save()
    {
        YandexGame.savesData.timerGame = timer.currectTime;
        YandexGame.savesData.NumberLevel = NumberLevel;
        YandexGame.SaveProgress();
    }
}
