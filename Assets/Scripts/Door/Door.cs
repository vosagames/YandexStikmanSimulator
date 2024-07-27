using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;
using YG;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject objectDoor, animationDoor;
    [SerializeField] private TimerControl timer;

    private void Awake()
    {
        animationDoor.SetActive(false);
        timer = FindObjectOfType<TimerControl>();
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
