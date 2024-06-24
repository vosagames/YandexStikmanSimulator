using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _Camera;

    [SerializeField] private Animator _camAnim;

    [SerializeField] private GameObject _menuButtons, _settingsButtons, _playButtons, _exitButtons;

    private void Start()
    {
        _Camera = GameObject.FindGameObjectWithTag("MainCamera");
        _camAnim = _Camera.GetComponent<Animator>();
    }
    public void Settings()
    {
        _menuButtons.SetActive(false);
        _camAnim.SetTrigger("Settings");
        Invoke("ShowSettings", 0.5f);
        
    }
    private void ShowSettings()
    {
        _settingsButtons.SetActive(true);
    }

    public void BackSettings()
    {
        _settingsButtons.SetActive(false);
        _camAnim.SetTrigger("SetBack");
        Invoke("ShowMenuButton", 0.5f);
    }
    private void ShowMenuButton()
    {
        _menuButtons.SetActive(true);
    }
    public void PlayMenu()
    {
        _menuButtons.SetActive(false);
        _camAnim.SetTrigger("SetUp");
        Invoke("ShowPlayMenu", 0.5f);
    }
    private void ShowPlayMenu()
    {
        _playButtons.SetActive(true);
    }
    public void BackPlay()
    {
        _playButtons.SetActive(false);
        _camAnim.SetTrigger("SetDown");
        Invoke("ShowMenuButton", 0.5f);
    }
    public void LoadSave()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }    

}
