using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public bool estPlace;
    public Calculateur calculateur;

    Vector3 positionInitiale;
    Transform parentInitial;
    Collider2D collider;

    void Start()
    {
        positionInitiale = transform.position;
        parentInitial = transform.parent;
        collider = GetComponent<Collider2D>();
    }

    public void AuDebutDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        // If object was in a slot, clear that slot value
        if (estPlace)
        {
            estPlace = false;

            Drop slot = transform.parent.GetComponent<Drop>();

            if (slot != null)
            {
                if (slot.estPremierSlot)
                    calculateur.RecevoirPremierNombre(0);
                else
                    calculateur.RecevoirDeuxiemeNombre(0);
            }
        }

        // Remove from slot and return to original parent
        transform.SetParent(parentInitial, true);

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

    if (transform.parent == parentInitial)
    {
        transform.position = positionInitiale;
    }
}
}