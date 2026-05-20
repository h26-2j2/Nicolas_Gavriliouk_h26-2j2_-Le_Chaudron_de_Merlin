using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragFrog : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 targetPosition;
    public float modifier;

    public TMP_FontAsset LaPolice;
    public AudioClip sonPotion;
    public TMP_Text texteModifier;
    AudioSource audioSource;

    // Initialise les éléments nécessaires et configure l'affichage du modificateur
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        texteModifier = GetComponentInChildren<TMP_Text>();

        // Affiche le modificateur avec un "+" s'il est positif
        if (modifier > 0)
        {
            texteModifier.text = $" +{modifier}";
        }
        else
        {
            texteModifier.text = $"{modifier}";
        }

        // J'ai dû recourir à l'IA pour trouver le code exact permettant d'accéder aux textes de manière plus manuelle, car je n'arrivais pas, pour une raison quelconque, à les configurer différemment dans le préfabriqué ; j'ai donc décidé de le faire manuellement, même si c'était « maudit ».
        
        texteModifier.fontSize = 8f;
        texteModifier.font = LaPolice;

        texteModifier.fontMaterial.SetFloat(
            ShaderUtilities.ID_OutlineWidth,
            0.3f
        );

        texteModifier.fontMaterial.SetColor(
            ShaderUtilities.ID_OutlineColor,
            Color.black
        );

        texteModifier.fontMaterial.SetColor(
            ShaderUtilities.ID_UnderlayColor,
            Color.clear
        );
    }

    // Déclenche le début du drag : l'objet se prépare à être déplacé
    public void AuDebutDrag(BaseEventData baseEventData)
    {
        // Passe l'objet en mode Kinematic pour qu'il suive le curseur proprement
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }

        // Joue un son quand la potion est prise
        audioSource.PlayOneShot(sonPotion);

        // Récupère la position du curseur dans le monde du jeu
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        targetPosition = positionCurseur;
    }

    // Met à jour la position cible pendant qu'on glisse l'objet
    public void AuDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        targetPosition = positionCurseur;
    }

    // Déplace l'objet en continu pour qu'il suive bien la position voulue
    void FixedUpdate()
    {
        if (rigidbody2D != null && rigidbody2D.bodyType == RigidbodyType2D.Kinematic)
        {
            rigidbody2D.MovePosition(targetPosition);
        }

        // Ce fonctionnement permet à l'objet de rester interactif pendant le déplacement.
    }

    // Remet l'objet en mode normal quand on relâche le drag
    public void AuFinDrag(BaseEventData baseEventData)
    {
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}