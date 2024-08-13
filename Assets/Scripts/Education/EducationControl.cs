using UnityEngine;
using YG;

public class EducationControl : MonoBehaviour
{
    [SerializeField] private GameObject mobileEducation;
    [SerializeField] private GameObject pcEducation;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true)
        {
            pcEducation.SetActive(false);
            mobileEducation.SetActive(true);
        }
        else if (YandexGame.EnvironmentData.isDesktop == true)
        {
            pcEducation.SetActive(true);
            mobileEducation.SetActive(false);
        }
    }
}
