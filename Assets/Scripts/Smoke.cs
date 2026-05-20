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

    // Petite fonction de test utilisée pendant le développement :P
    private void Proot()
    {
        Debug.Log("Proot"); 
    }

    // Lance l'effet de fumée, l'animation et le son associé
    public void Smoke()
    {
        // Rend la fumée visible
        sr.enabled = true;

        // Lance l'animation de fumée
        anim.SetTrigger("PlaySmoke");

        // Joue le son de fumée
        audioSource.PlayOneShot(smokeSound);

        // Cache automatiquement la fumée après 1 seconde
        Invoke("CacheSmoke", 1f);

        Proot();
    }

    // Cache le sprite de fumée une fois l'animation terminée
    void CacheSmoke()
    {
        sr.enabled = false;
    }
}