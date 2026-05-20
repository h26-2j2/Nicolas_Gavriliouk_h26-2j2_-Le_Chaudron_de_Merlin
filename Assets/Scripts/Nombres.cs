using UnityEngine;
using TMPro;

public class Nombres : MonoBehaviour
{
    public TMP_Text texteFactor;
    public float factor = 1f;
    public TMP_FontAsset LaPolice;

    // C'est encore le même problème : je ne peux pas modifier directement le TMP_Text depuis le préfab, je dois donc le modifier manuellement :/
    void Start()
    {
        // Récupère automatiquement le texte enfant de l'objet
        texteFactor = GetComponentInChildren<TMP_Text>();

        // Affiche la valeur du facteur sur l'objet
        texteFactor.text = $"{factor}";

        // Modifie l'apparence du texte
        texteFactor.fontSize = 15f;
        texteFactor.font = LaPolice;

        // Ajoute un contour noir autour du texte pour le rendre plus lisible
        texteFactor.fontMaterial.SetFloat(
            ShaderUtilities.ID_OutlineWidth,
            0.3f
        );

        texteFactor.fontMaterial.SetColor(
            ShaderUtilities.ID_OutlineColor,
            Color.black
        );

        // Désactive l'effet d'ombre du texte
        texteFactor.fontMaterial.SetColor(
            ShaderUtilities.ID_UnderlayColor,
            Color.clear
        );

        // Ajuste légèrement la position du texte sur l'objet
        texteFactor.transform.localPosition = new Vector3(0f, 0.2f, 0f);
    }
}