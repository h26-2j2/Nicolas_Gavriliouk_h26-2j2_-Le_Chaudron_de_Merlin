using UnityEngine;
using UnityEngine.UI;

public class Voix : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] voix;

    public int indexVoix;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("StartingVoix",1.5f);
        
    }

    public void JoueVoix()
    {
        audioSource.PlayOneShot(voix[indexVoix]);
    }

    public void StartingVoix()
    {
        audioSource.PlayOneShot(voix[indexVoix]);
    }
}