using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;
using YG;

public class UIcontrol : MonoBehaviour
{
    [SerializeField] private GameObject UImenu;
    [SerializeField] private TimerControl timer;
    [SerializeField] private GameObject SettingsForMobile;
    [SerializeField] private GameObject virtualCamera;

    private bool Switch = false;
    private bool wait = false;
    private bool MenuForMobile;
    private GameObject _destroyVirtualCamera;

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
            _destroyVirtualCamera = Instantiate(virtualCamera, Camera.main.transform.position, Camera.main.transform.rotation);
            GameObject[] ObjectsPlayerTag = GameObject.FindGameObjectsWithTag("Player");
            for(int element = 0; element < ObjectsPlayerTag.Length; element++)
            {
                if (ObjectsPlayerTag[element].GetComponent<PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerController>().isMove = false;
                }
                else if (ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>().isMove = false;
                }
                else if (ObjectsPlayerTag[element].GetComponent<Type3PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<Type3PlayerController>().isMove = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Switch == true && wait == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            UImenu.SetActive(false);
            wait = true;
            Switch = false;
            Invoke("Wait", 1f);
            _destroyVirtualCamera.SetActive(false);
            Destroy(_destroyVirtualCamera, 2f);
            GameObject[] ObjectsPlayerTag = GameObject.FindGameObjectsWithTag("Player");
            for (int element = 0; element < ObjectsPlayerTag.Length; element++)
            {
                if (ObjectsPlayerTag[element].GetComponent<PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerController>().isMove = true;
                }
                else if (ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>().isMove = true;
                }
                else if (ObjectsPlayerTag[element].GetComponent<Type3PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<Type3PlayerController>().isMove = true;
                }
            }
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
        if (MenuForMobile == false && wait == false)
        {
            UImenu.SetActive(true);
            wait = true;
            MenuForMobile = true;
            Invoke("Wait", 1f);
            _destroyVirtualCamera = Instantiate(virtualCamera, Camera.main.transform.position, Camera.main.transform.rotation);
            GameObject[] ObjectsPlayerTag = GameObject.FindGameObjectsWithTag("Player");
            for (int element = 0; element < ObjectsPlayerTag.Length; element++)
            {
                if (ObjectsPlayerTag[element].GetComponent<PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerController>().isMove = false;
                }
                else if (ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>().isMove = false;
                }
                else if (ObjectsPlayerTag[element].GetComponent<Type3PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<Type3PlayerController>().isMove = false;
                }
            }
        }
        if (MenuForMobile == true && wait == false)
        {
            UImenu.SetActive(false);
            wait = true;
            MenuForMobile = false;
            Invoke("Wait", 1f);
            _destroyVirtualCamera.SetActive(false);
            Destroy(_destroyVirtualCamera, 2f);
            GameObject[] ObjectsPlayerTag = GameObject.FindGameObjectsWithTag("Player");
            for (int element = 0; element < ObjectsPlayerTag.Length; element++)
            {
                if (ObjectsPlayerTag[element].GetComponent<PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerController>().isMove = true;
                }
                else if (ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>())
                {
                    ObjectsPlayerTag[element].GetComponent<PlayerControllerType2>().isMove = true;
                }
                else if (ObjectsPlayerTag[element].GetComponent<Type3PlayerController>())
                {
                    ObjectsPlayerTag[element].GetComponent<Type3PlayerController>().isMove = true;
                }
            }
        }
    }
    private void Save()
    {
        YandexGame.savesData.timerGame = timer.currectTime;
        YandexGame.SaveProgress();
    }
}
