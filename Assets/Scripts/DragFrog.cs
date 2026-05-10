using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragFrog : MonoBehaviour
{
    public Calculateur calculateur;

    // public AudioClip sonPotion;

    AudioSource audiosource;

    // Vector3 positionInitiale;
    Collider2D collider;
    Rigidbody2D rigidbody2D;
    //   Transform ListePotions;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
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

}
}