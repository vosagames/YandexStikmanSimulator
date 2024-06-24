using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using static GameManager;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float _dealy = 0.6f;

    [SerializeField] private List <string> _gameOverText = new List<string>();
    [SerializeField] private List<TMP_Text> _text = new List<TMP_Text>();

    [SerializeField] private List<AudioSource> _audioKeys;

    private int index = 0;

    private void Start()
    {
        Invoke("loadLevel", 5f);
        NumberPlayer++;
        _gameOverText[0] = $"Îáðàçåö íîìåð: {NumberPlayer}";
        _gameOverText[1] = "Ñòàòóñ: #ÓÍÈ×ÒÎÆÅÍ";

        StartCoroutine(printTXT());
    }
    private IEnumerator printTXT()
    {
        foreach (var txt in _gameOverText[index])
        {
            _text[index].text += txt;
            AudioKeys();
            yield return new WaitForSeconds(_dealy);
            if (_text[index].text == _gameOverText[index])
            {
                index++;
                StartCoroutine(printTXT());
            }
        }
    }
    private void AudioKeys()
    {
        int id = Random.Range(0, _audioKeys.Count);
        _audioKeys[id].Play();
    }
    private void loadLevel() => SceneManager.LoadScene(NumberLevel);

}
