using UnityEngine;

public class Detector : MonoBehaviour
{
    public GestionNiveauPotions gestionNiveauPotions;

    // Détecte quand une potion entre dans la zone de collision du détecteur
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Récupère la valeur du modificateur de l'objet qui vient d'entrer

        // DragFrog c'est les potions.
        float modifier = other.GetComponent<DragFrog>().modifier;

        // Trouve le script Calculateur dans la scène
        Calculateur calculateur = FindObjectOfType<Calculateur>();

        // Envoie le modificateur récupéré au calculateur
        calculateur.modificateur = modifier;

        // Lance l'effet de fumée pour montrer qu'une action s'est produite
        gestionNiveauPotions.Smoke.GetComponent<SmokeEffect>().Smoke();

        // Supprime l'objet après utilisation
        Destroy(other.gameObject);
    }
}