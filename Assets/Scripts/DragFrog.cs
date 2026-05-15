using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragFrog : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 targetPosition;
    public float modifier;

    public TMP_FontAsset LaPolice;
      public TMP_Text texteModifier;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        texteModifier = GetComponentInChildren<TMP_Text>();


        if (modifier > 0)
        {
            texteModifier.text = $" +{modifier}";
        } else
        {
            texteModifier.text = $"{modifier}";
        }
        
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

        // texteModifier.transform.localPosition = new Vector3(0f, 0.2f, 0f);
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