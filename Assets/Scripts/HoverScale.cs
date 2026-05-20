using UnityEngine;
using UnityEngine.EventSystems;


// IMPORTANT!!!
// J’utilise IPointerEnterHandler et IPointerExitHandler plutôt que OnMouseEnter,
// car mes objets sont déplacés et parfois leur collider est désactivé pendant le drag,
// ce qui rend OnMouseEnter moins fiable dans mon cas. Pour être honnête, je ne comprends pas tout à fait pourquoi OnMouseEnter ne fonctionne pas, mais j'ai réussi à résoudre ce problème technique grâce à l'IA.

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 targetScale;
    private Vector3 scaleInitial;

    public float scaleMultiplier = 1.2f;

    // Sauvegarde la taille initiale de l'objet
    void Start()
    {
        scaleInitial = transform.localScale;
        targetScale = scaleInitial;
    }
    // *** C'est là que j'ai découvert ce qu'était le « Vector 3 lerp » grâce à l'IA. Cela m'a permis de créer une animation de survol. 


    // Change progressivement la taille de l'objet pour créer une animation plus fluide
    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            10f * Time.deltaTime
        );
    }

    // Agrandit l'objet quand le curseur passe dessus. Tant que le curseur reste sur l'objet, le multiplicateur augmente toutes les secondes.
    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = scaleInitial * scaleMultiplier;
    }

    // Remet l'objet à sa taille normale quand le curseur quitte l'objet
    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = scaleInitial;
    }

    // Met à jour la taille de référence après certains déplacements ou changements
    public void RefreshScale()
    {
        scaleInitial = transform.localScale;
        targetScale = scaleInitial;
    }
}


