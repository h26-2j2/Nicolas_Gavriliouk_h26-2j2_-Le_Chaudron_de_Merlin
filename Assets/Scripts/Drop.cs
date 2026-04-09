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

        if (estPremierSlot)
            calculateur.RecevoirPremierNombre(valeur);
        else
            calculateur.RecevoirDeuxiemeNombre(valeur);

        Debug.Log("Valeur reçue : " + valeur);

        objectDeplace.transform.SetParent(this.transform);
        objectDeplace.transform.localPosition = Vector3.zero;
    }
}