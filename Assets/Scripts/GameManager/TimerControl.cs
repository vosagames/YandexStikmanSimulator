using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class TimerControl : MonoBehaviour
{
    public float currectTime;

    [SerializeField] private TMP_Text _timer;
    [SerializeField] private float saveTime;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        if(YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void Update()
    {
        currectTime = saveTime += 1 * Time.deltaTime;
        _timer.text = currectTime.ToString("F2");
    }

    public void GetLoad()
    {
        saveTime = YandexGame.savesData.timerGame;
    }

}
