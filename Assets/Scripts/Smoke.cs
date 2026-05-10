using UnityEngine;


public class SmokeEffect : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public AudioClip smokeSound;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        sr.enabled = false;
    }
    private void Proot()
    {
    Debug.Log("Proot"); 
    }
    public void Smoke()
    {
            sr.enabled = true; 
            anim.SetTrigger("PlaySmoke");
            audioSource.PlayOneShot(smokeSound);
            Invoke("HideSmoke", 1f);
            Proot();
    }

    void HideSmoke()
{
    sr.enabled = false;
}
}

