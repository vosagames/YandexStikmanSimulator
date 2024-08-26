using UnityEditor;
using UnityEngine;
using YG;

public class MouseCursorControl : MonoBehaviour
{
    private void Start()
    {
        HideCursor();
    }
    public void HideCursor()
    {
        if (YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (YandexGame.EnvironmentData.isDesktop == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
