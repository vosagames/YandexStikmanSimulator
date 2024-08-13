using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class VoiceDictorControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> titles = new List<GameObject>();
    [SerializeField] private List<AudioSource> voice = new List<AudioSource>();

    private int id = 0;

    public void voiceControl()
    {
        voice[id].Play();
        id++;
    }

    private void titlesControl()
    {

    }
}
