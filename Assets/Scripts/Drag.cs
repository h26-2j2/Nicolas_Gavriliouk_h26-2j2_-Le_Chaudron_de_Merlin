using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    public bool estPlace;
    public Calculateur calculateur;

    public AudioClip sonIngredient;

    AudioSource audiosource;

    GestionNiveauPotions gestionNiveauPotions;
    Collider2D collider;
    Rigidbody2D rigidbody2D;

    // Initialise les références nécessaires pour pouvoir déplacer l'objet correctement
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gestionNiveauPotions = GameObject.FindObjectOfType<GestionNiveauPotions>();;
        collider = GetComponent<Collider2D>();
        audiosource = GetComponent<AudioSource>();
        calculateur = GameObject.FindAnyObjectByType<Calculateur>();
    }

    // Déclenché quand on commence à glisser l'objet
    public void AuDebutDrag(BaseEventData baseEventData)
    {
        // Désactive la physique pendant le déplacement pour éviter que l'objet résiste au drag
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        // Récupère la position de la souris ou du doigt à l'écran
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        // Transforme la position de l'écran en position dans le monde du jeu
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        transform.position = positionCurseur;

        // Joue un son quand l'objet est pris
        audiosource.PlayOneShot(sonIngredient);

        // Si l'objet était déjà placé dans un slot, on le retire du calcul en cours
        if (estPlace)
        {
            estPlace = false;

            // Vérifie dans quel slot l'objet était placé
            Drop slot = transform.parent.GetComponent<Drop>();

            // Envoie 0 au calculateur pour retirer la valeur précédente
            if (slot != null)
            {
                if (slot.estPremierSlot)
                    calculateur.RecevoirPremierNombre(0);
                else
                    calculateur.RecevoirDeuxiemeNombre(0);
            } 
            else 
            {
                
            }
        }

        // Remet l'objet dans la liste principale pendant le drag
        transform.SetParent(gestionNiveauPotions.listePotions, false);

        // Désactive la collision pendant qu'on le déplace
        collider.enabled = false;
    }

    // Déclenché pendant que l'objet est en train d'être déplacé
    public void AuDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        // Suit la position du curseur en temps réel
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        transform.position = positionCurseur;
    }

    // Déclenché quand on relâche l'objet
    public void AuFinDrag(BaseEventData baseEventData)
    {
        // Réactive la collision à la fin du déplacement
        collider.enabled = true;

        // Réactive la physique pour que l'objet redevienne normal
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        // Si l'objet est encore dans la liste principale, on recalcule sa position dans l'interface
        if (transform.parent == gestionNiveauPotions.listePotions)
        {
            transform.SetParent(gestionNiveauPotions.listePotions, false);
            LayoutRebuilder.ForceRebuildLayoutImmediate(gestionNiveauPotions.listePotions.GetComponent<RectTransform>());
        }
    }
}