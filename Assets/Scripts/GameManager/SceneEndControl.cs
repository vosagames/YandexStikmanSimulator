using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneEndControl : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    [SerializeField] private TMP_Text _timerResult;
    [SerializeField] private TMP_Text _attemptCounter;

    private float _currectTime;
    private int _attempt;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        if(YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    public void GetLoad()
    {
        _attempt = YandexGame.savesData.NumberPlayer;
        _currectTime = YandexGame.savesData.timerGame;
        _attempt -= 2008;
    }
    public void Result()
    {
        _timerResult.text = _currectTime.ToString("F2");
        _attemptCounter.text = _attempt.ToString();
    }
    public void LoadMenu()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
        SceneManager.LoadScene(0);
    }

}
