using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class UIcontrol : MonoBehaviour
{
    [SerializeField] private GameObject UImenu;

    private bool Switch = false;
    private bool wait = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UImenu.SetActive(false);
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
        SceneManager.LoadScene(NumberLevel);
    }
    private void Wait()
    {
        wait = false;
    }
}
