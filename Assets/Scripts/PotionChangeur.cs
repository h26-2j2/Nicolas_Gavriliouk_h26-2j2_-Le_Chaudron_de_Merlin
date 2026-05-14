using UnityEngine;

public class PotionChangeur : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] potionFrames;

    private Nombres nombres;



    void Awake() {
        nombres = GetComponent<Nombres>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
         int index = (int)nombres.factor - 1;
         index = Mathf.Clamp(index, 0, potionFrames.Length - 1);
        ChangePotion(index);
    }

    public void ChangePotion(int index)
    {

        spriteRenderer.sprite = potionFrames[index];
    }

    
}