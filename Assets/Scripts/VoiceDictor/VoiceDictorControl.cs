using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using static GameManager;


public class VoiceDictorControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> titles = new List<GameObject>();

    [SerializeField] private List<AudioSource> voice = new List<AudioSource>();

    [SerializeField] private List<float> waitTime = new List<float>();

    [SerializeField] private float destroyTime = 5f;

    private int idForVoice = 0;
    public int idForTitles = 0;
    private int idForWaitTime = 0;

    private void Start()
    {
        for(int i = 0; i < titles.Count; i++)
        {
            titles[i].SetActive(false);
        }
        Invoke("voiceControl", 1f);
    }

    public void voiceControl()
    {
        voice[idForVoice].Play();
        StartCoroutine(titleForFirstAudio());
    }

    private IEnumerator titleForFirstAudio()
    {
        Invoke("titlesControl", waitTime[idForWaitTime]);
        yield return new WaitForSeconds(1f);
        yield return titleForFirstAudio();
    }
    private void titlesControl()
    {
        switch (NumberLevel)
        {
            case 1:
                {
                    switch (idForVoice)
                    {
                        case 0:
                            {
                                if (idForTitles == 4)
                                {
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else
                                {
                                    titleCreate();
                                }
                            }
                            break;
                        case 1:
                            {
                                if(idForTitles == 6)
                                {
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else
                                {
                                    titleCreate();
                                }
                            }
                            break;
                        case 2:
                            {
                                if (idForTitles == 9)
                                {
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else
                                {
                                    titleCreate();
                                }
                            }
                            break;
                    }
                }
                break;
            case 2:
                {
                    switch (idForVoice)
                    {
                        case 0:
                            {
                                if (idForTitles == 0)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                        case 1:
                            {
                                if (idForTitles == 1)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                    }
                }
                break;
            case 3:
                {
                    switch (idForVoice)
                    {
                        case 0: 
                            {
                                if (idForTitles == 1)
                                {
                                    Invoke("titleCreate", waitTime[1]);
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else
                                {
                                    titleCreate();
                                }
                            }
                            break;
                        case 1:
                            {
                                if (idForTitles == 2)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                        case 2:
                            {
                                if (idForTitles == 3)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                    }
                }
                break;
            case 4:
                {
                    switch (idForVoice)
                    {
                        case 0:
                            {
                                if (idForTitles == 1)
                                {
                                    Invoke("titleCreate", waitTime[1]);
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else
                                {
                                    titleCreate();
                                }
                            }
                            break;
                    }
                }
                break;
            case 5:
                {
                    switch (idForVoice)
                    {
                        case 0:
                            {
                                if (idForTitles == 0)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                        case 1:
                            {
                                if (idForTitles == 1)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                    }
                }
                break;
            case 6:
                {
                    switch (idForVoice)
                    {
                        case 0:
                            {
                                if(idForTitles == 1)
                                {
                                    Invoke("titleCreate", waitTime[1]);
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                                else { titleCreate(); }
                            }
                            break;
                        case 1:
                            {
                                if(idForTitles == 2)
                                {
                                    titleCreate();
                                    idForVoice++;
                                    StopAllCoroutines();
                                }
                            }
                            break;
                    }
                }
                break;
        }
    }

    private void titleCreate()
    {
        titles[idForTitles].SetActive(true);
        Destroy(titles[idForTitles], destroyTime);
        idForTitles++;
    }

}
