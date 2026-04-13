using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public bool estPlace;
    public Calculateur calculateur;

    public AudioClip sonPotion;

    AudioSource audiosource;

    Vector3 positionInitiale;
    Transform parentInitial;
    Collider2D collider;


    void Start()
    {
        positionInitiale = transform.position;
        parentInitial = transform.parent; // le parent est just la hierarchy de unity ou root
        collider = GetComponent<Collider2D>();
        audiosource = GetComponent<AudioSource>();
        
    }

    public void AuDebutDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        transform.position = positionCurseur;


         audiosource.PlayOneShot(sonPotion);

        
        // Cette condition verfie si il y a quelque chose dans parent qui conteint drop script. sa return 0.
        if (estPlace)
        {
            estPlace = false;

            Drop slot = transform.parent.GetComponent<Drop>(); // Dans la Hierarchy je vais chercher son parent qui contient le script Drop 
             
            if (slot != null)
            {
                if (slot.estPremierSlot)
                    calculateur.RecevoirPremierNombre(0);
                else
                    calculateur.RecevoirDeuxiemeNombre(0);
            }

           

        }

        
        transform.SetParent(parentInitial, true); // Cette line ramène son enfant a son parent initial. son parent initial cest juste la hiearchie ou root.

        

        collider.enabled = false;

        
    }

    public void AuDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        transform.position = positionCurseur;
    }

    public void AuFinDrag(BaseEventData baseEventData)
{
    collider.enabled = true;
    
    if (transform.parent == parentInitial)
    {
        transform.position = positionInitiale;
    }
}
}