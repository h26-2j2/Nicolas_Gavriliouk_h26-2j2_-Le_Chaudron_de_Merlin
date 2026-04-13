using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
    public Calculateur calculateur;
    public bool estPremierSlot;

    public void AuDrop(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject objectDeplace = pointerEventData.pointerDrag;
        objectDeplace.GetComponent<Drag>().estPlace = true;






        float valeur = objectDeplace.GetComponent<Nombres>().factor;

        

        // Parmi les deux "slots", il y a un qui est vrai. Ceci determine si c'est le premier. 
        if (estPremierSlot)
            calculateur.RecevoirPremierNombre(valeur);
        else
            calculateur.RecevoirDeuxiemeNombre(valeur);

      

        objectDeplace.transform.SetParent(this.transform);
        objectDeplace.transform.localPosition = Vector3.zero;


          Debug.Log("Valeur reçue : " + valeur);
        //  On n'a pâs encore appris comment faire des instances :(
    }
}