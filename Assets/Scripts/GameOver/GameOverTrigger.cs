using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TimerControl timer;

    private void Start()
    {
        _panel = GameObject.FindGameObjectWithTag("HidePanel");
        _panel.SetActive(false);
        timer = FindObjectOfType<TimerControl>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _panel.SetActive(true);
            Invoke("LoadGameOverScene", 1.1f);
        }
    }
    private void LoadGameOverScene()
    {
        Save();
        SceneManager.LoadScene("Game Over");
    }
    private void Save()
    {
        YandexGame.savesData.timerGame = timer.currectTime;
        YandexGame.SaveProgress();
    }
}
