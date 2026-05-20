using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
    public Calculateur calculateur;
    public bool estPremierSlot;
    public GestionNiveauPotions gestionNiveauPotions;
    public float offset;

    // S'exécute quand un objet est lâché dans cette zone
    public void AuDrop(BaseEventData baseEventData)
    {
        // Récupère l'objet qui est en train d'être déplacé
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject objectDeplace = pointerEventData.pointerDrag;

        // Indique que l'objet a bien été placé dans un slot
        objectDeplace.GetComponent<Drag>().estPlace = true;

        // Récupère la valeur de l'objet déposé
        float valeur = objectDeplace.GetComponent<Nombres>().factor;

        // Vérifie si on est dans le premier slot ou dans le deuxième
        if (estPremierSlot)
        {
            gestionNiveauPotions.potionGauche = objectDeplace;
            calculateur.RecevoirPremierNombre(valeur);         
        }
        else
        {
            gestionNiveauPotions.potionDroite = objectDeplace;
            calculateur.RecevoirDeuxiemeNombre(valeur);
        }

        // Place l'objet directement dans le slot
        objectDeplace.transform.SetParent(this.transform, false);
        objectDeplace.transform.localScale = Vector3.one;
        objectDeplace.transform.localPosition = new Vector3(0, offset, 0);

        // Met à jour la taille de l'objet après le déplacement
        objectDeplace.GetComponent<HoverScale>().RefreshScale();

        
    }
}