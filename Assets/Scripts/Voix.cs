using UnityEngine;

public class Voix : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Dialogues de victoire")]
    public AudioClip[] voixVictoire;

    [Header("Dialogues d'indice")]
    public AudioClip[] voixIndice;

    [Header("Bienvenue")]
    public AudioClip bienvenue;

    public AudioClip tutoriel;

    public bool reussi = false;

    public bool pause = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(bienvenue);
        Invoke("JoueVoixTutoriel", 3f);
        InvokeRepeating("JoueVoixIndice", 10f, 10f);
    }
    
    

    private void Update() {

        if(reussi)
        {
            CancelInvoke("JoueVoixIndice");
        }
    }

    public void JoueVoixTutoriel()
    {

        
        audioSource.PlayOneShot(tutoriel);
    }

    public void JoueVoixVictoire()
    {

        pause = true;
        int index = Random.Range(0, voixVictoire.Length);

        audioSource.PlayOneShot(voixVictoire[index]);
        Invoke("FinPauseDialogue", voixVictoire[index].length);

    }

    public void JoueVoixIndice()
    {

        if (pause)
    {
        return;
    }

        int index = Random.Range(0, voixIndice.Length);

        audioSource.PlayOneShot(voixIndice[index]);
    }


    void FinPauseDialogue()
{
    pause = false;
}

}