
using System.Collections.Generic;
using UnityEngine;

public class AudioWalk : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioWalk;
    [SerializeField] private List<AudioSource> _audioRun;
    [SerializeField] private List<AudioSource> _audioJumpStart;
    public void AudioWalkPlay()
    {
        int audioIndex = Random.Range(0, _audioWalk.Count);
        _audioWalk[audioIndex].Play();
    }
    public void AudioRunPlay()
    {
        int audioIndexR = Random.Range(0, _audioRun.Count);
        _audioWalk[audioIndexR].Play();
    }
    public void AudioJumpStartPlay()
    {
        int index = Random.Range(0, _audioJumpStart.Count);
        _audioJumpStart[index].Play();
    }

}
