using UnityEngine;
using UnityEngine.EventSystems;

public class DragFrog : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 targetPosition;
    public float modifier;

   
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AuDebutDrag(BaseEventData baseEventData)
    {
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }

        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        targetPosition = positionCurseur;
    }

    public void AuDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 positionCurseur = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        positionCurseur.z = 0;
        targetPosition = positionCurseur;
    }

    void FixedUpdate() 
    {
        if (rigidbody2D != null && rigidbody2D.bodyType == RigidbodyType2D.Kinematic)
        {
            rigidbody2D.MovePosition(targetPosition);
        }

        // Ce code permet à l'objet de rester détectable à chaque image grâce à des collisions ou des triggers.
    }

    public void AuFinDrag(BaseEventData baseEventData)
    {
        if (rigidbody2D != null)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}