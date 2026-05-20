using UnityEngine;

public class PotionChangeur : MonoBehaviour
{
    // *** Il aurait dû s'écrire « IngredientChanger », mais des modifications de dernière minute ont été apportées...
    public SpriteRenderer spriteRenderer;

    public Sprite[] potionFrames;

    private Nombres nombres;

    // Initialise les composants nécessaires avant le début du jeu
    void Awake()
    {
        nombres = GetComponent<Nombres>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Choisit automatiquement la bonne image selon la valeur du nombre
    void Start()
    {
        int index = (int)nombres.factor - 1;

        // Empêche l'index de dépasser les limites du tableau
        // Ce code a été rédigé principalement à des fins de sûreté mais je pense que cela ne serait plus nécessaire.
        index = Mathf.Clamp(index, 0, potionFrames.Length - 1);

        ChangePotion(index);
    }

    // Change l'image affichée par le SpriteRenderer
    public void ChangePotion(int index)
    {
        spriteRenderer.sprite = potionFrames[index];
    }
}