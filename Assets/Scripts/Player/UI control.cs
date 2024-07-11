using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;
using YG;

public class UIcontrol : MonoBehaviour
{
    [SerializeField] private GameObject UImenu;
    [SerializeField] private TimerControl timer;
    [SerializeField] private GameObject SettingsForMobile;

    private bool Switch = false;
    private bool wait = false;
    private bool MenuForMobile;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UImenu.SetActive(false);
            SettingsForMobile.SetActive(true);
        }
        else if (YandexGame.EnvironmentData.isDesktop == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            UImenu.SetActive(false);
            SettingsForMobile.SetActive(false);
        }
        timer = FindObjectOfType<TimerControl>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Switch == false && wait == false)
        {
            UImenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            wait = true;
            Switch = true;
            Invoke("Wait", 1f);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Switch == true && wait == false)
        {
            UImenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            wait = true;
            Switch = false;
            Invoke("Wait", 1f);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Resets()
    {
        Save();
        SceneManager.LoadScene(NumberLevel);
    }
    private void Wait()
    {
        wait = false;
    }
    public void OpenMenu()
    {
        if(MenuForMobile == false && wait == false)
        {
            UImenu.SetActive(true);
            wait = true;
            MenuForMobile = true;
            Invoke("Wait", 1f);
        }
        if(MenuForMobile == true && wait == false)
        {
            UImenu.SetActive(false);
            wait = true;
            MenuForMobile = false;
            Invoke("Wait", 1f);
        }
    }
    private void Save()
    {
        YandexGame.savesData.timerGame = timer.currectTime;
        YandexGame.SaveProgress();
    }
}
