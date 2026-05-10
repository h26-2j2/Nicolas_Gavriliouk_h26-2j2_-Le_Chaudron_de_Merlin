using UnityEngine;

public class PotionChangeur : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] potionFrames;

    void Start()
    {
        // ChangePotion(0);
    }

    public void ChangePotion(int index)
    {
        spriteRenderer.sprite = potionFrames[index];
    }

    
}