using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 targetScale;
    private Vector3 scaleInitial;

    public float scaleMultiplier = 1.2f;

    void Start()
    {
        scaleInitial = transform.localScale;
        targetScale = scaleInitial;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            10f * Time.deltaTime
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = scaleInitial * scaleMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = scaleInitial;
    }

    public void RefreshScale()
{
    scaleInitial = transform.localScale;
    targetScale = scaleInitial;
}
}