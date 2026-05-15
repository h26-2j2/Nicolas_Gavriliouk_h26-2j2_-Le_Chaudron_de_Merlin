using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public int cible = 0;
    public int move = 0;

    public TMP_Text texteCible;
    public TMP_Text texteMove;

    public Calculateur calculateur;

    public float resultat;


    void Start()
    {
        texteMove.text = $"Mouvement: {move}";
        texteCible.text = $"Cible: {cible}";
    }
    public void AjouterMouvement()
    {
        move++;

        texteMove.text = $"Mouvement: {move}";
    }
    private void Update() {
        resultat = calculateur.resultat;

    if (resultat == cible) 
    {
        Debug.Log("Victoire");
    }


    }
}