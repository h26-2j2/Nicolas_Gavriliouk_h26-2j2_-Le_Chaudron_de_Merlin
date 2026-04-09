using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{

    public bool estPlace;
    Vector3 positionInitiale;
    Collider2D collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positionInitiale = transform.position;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AuDebutDrag(BaseEventData baseEventData)
    {
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
        if(estPlace == false){
            transform.position = positionInitiale;
        }
    }
   
}
