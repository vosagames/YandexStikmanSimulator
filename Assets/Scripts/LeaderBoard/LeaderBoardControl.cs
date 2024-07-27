using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LeaderBoardControl : MonoBehaviour
{
    private void Start()
    {
        NewRecord();
    }
    public void NewRecord()
    {
        YandexGame.NewLBScoreTimeConvert("times", YandexGame.savesData.timerGame);
    }
}
