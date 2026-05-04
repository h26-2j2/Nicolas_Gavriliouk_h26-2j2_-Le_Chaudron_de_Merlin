using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    public bool estPlace;
    public Calculateur calculateur;

    public AudioClip sonPotion;

    AudioSource audiosource;

    // Vector3 positionInitiale;
    GestionNiveauPotions gestionNiveauPotions;
    Collider2D collider;
Rigidbody2D rigidbody2D;
    //   Transform ListePotions;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gestionNiveauPotions = GameObject.FindObjectOfType<GestionNiveauPotions>();;
        // positionInitiale = transform.position;
        
        // parentInitial = transform.listePotions; // le parent est just la hierarchy de unity ou root
        transform.SetParent(gestionNiveauPotions.listePotions, false);
        collider = GetComponent<Collider2D>();
        audiosource = GetComponent<AudioSource>();

        calculateur = GameObject.FindAnyObjectByType<Calculateur>();

        
    }

    public void AuDebutDrag(BaseEventData baseEventData)
    {
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static; // Désactive la physique pendant le drag
        }
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
            } else 
            {
                
            }

           

        }

        
        transform.SetParent(gestionNiveauPotions.listePotions,false); // Cette line ramène son enfant a son parent initial. son parent initial cest juste la hiearchie ou root.
        // transform.localPosition = new Vector2(0,0);
        

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
   
    if (rigidbody2D != null)
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic; // Réactive la physique après le drag
    }
    
    if (transform.parent == gestionNiveauPotions.listePotions)
    {
        // transform.parent = listePotions;
        transform.SetParent(gestionNiveauPotions.listePotions, false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(gestionNiveauPotions.listePotions.GetComponent<RectTransform>());
        // transform.localPosition = new Vector2(0,0);
    }
}
}