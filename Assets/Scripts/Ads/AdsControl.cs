using UnityEngine;
using YG;

public class AdsControl : MonoBehaviour
{
    [SerializeField] private GameObject clueText;
    [SerializeField] private GameObject buttonAds;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;



    private void Start()
    {
        clueText.SetActive(false);
    }

    private void Rewarded(int id)
    {
        if(id == 1)
        {
            ClueShow();
        }
    }

    private void ClueShow()
    {
        clueText.SetActive(true);
        buttonAds.SetActive(false);
    }

    public void RewardAdShow(int id)
    {
        YandexGame.RewVideoShow(id);
    }

}
