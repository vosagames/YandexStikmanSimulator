using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject script, script2;
    [SerializeField] AudioSource _leverAudio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        script.SetActive(false);
        script2.SetActive(false);
    }
    private bool use = false;

    public void UseHandle()
    {
        _leverAudio.Play();
        if(use == false)
        {
            animator.SetFloat("speed", 1f);
            script.SetActive(true);
            script2.SetActive(false);
            use = true;
        }
        else
        {
            animator.SetFloat("speed", -1f);
            script.SetActive(false);
            script2.SetActive(true);
            use = false;
        }
        animator.SetTrigger("use");
    }
}
