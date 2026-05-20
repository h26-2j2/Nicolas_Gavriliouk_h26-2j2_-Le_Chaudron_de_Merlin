using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public int cible = 0;
    public int move = 0;

    public TMP_Text texteCible;
    public TMP_Text texteMove;
    public TMP_Text texteReussi;

    public Calculateur calculateur;

    public float resultat;

    public GameObject VictoireCanvas;
     public Voix voix;
    // Initialise l'interface du HUD au début du niveau
    void Start()
    {
        // Cache l'écran de victoire au départ
        VictoireCanvas.SetActive(false);

        // Affiche les valeurs de départ du nombre de coups et de la cible
        texteMove.text = $"{move}";
        texteCible.text = $"{cible}";
    }

    // Ajoute un mouvement au compteur chaque fois qu'un calcule est faite
    public void AjouterMouvement()
    {
        move++;

        // Met à jour le texte affiché à l'écran
        texteMove.text = $"{move}";
    }

    // Vérifie constamment si le joueur a atteint la bonne réponse
    private void Update()
    {
        resultat = calculateur.resultat;

        // Si le résultat du calcul est égal à la cible, le joueur gagne
        if (resultat == cible)
        {
            voix.reussi = true;
            // Affiche l'écran de victoire
            VictoireCanvas.SetActive(true);

            // Affiche un message avec le nombre de coups utilisés
            texteReussi.text = $"Bravo!  Tu as réussi ce niveau en {move} coups.";
        }
    }
}