using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        _panel = GameObject.FindGameObjectWithTag("HidePanel");
        _panel.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _panel.SetActive(true);
            Invoke("LoadGameOverScene", 1.1f);
        }
    }
    private void LoadGameOverScene() => SceneManager.LoadScene("Game Over");
}
