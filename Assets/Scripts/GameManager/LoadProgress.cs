using UnityEngine;
using YG;
using static GameManager;
using UnityEngine.SceneManagement;

public class LoadProgress : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        if(YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }


    public void GetLoad()
    {
        Health = YandexGame.savesData.Health;
        NumberLevel = YandexGame.savesData.NumberLevel;
        NumberPlayer = YandexGame.savesData.NumberPlayer;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(NumberLevel);
    }
}
