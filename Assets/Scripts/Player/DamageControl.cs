using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    [SerializeField] private GameObject _damagePanel;
    [SerializeField] private List<AudioSource> _damageAudio;

    public void Damage(int damage)
    {
        GameObject obj = Instantiate(_damagePanel);
        Destroy(obj, 3f);
        int index = Random.Range(0, _damageAudio.Count);
        _damageAudio[index].Play();
        int hp = GameManager.Health;
        hp -= damage;
    }
}
