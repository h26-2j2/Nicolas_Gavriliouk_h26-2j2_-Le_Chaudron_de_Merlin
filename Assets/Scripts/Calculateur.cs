using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    public float factor1 = 0;
    public float factor2 = 0;

    public GameObject IngredientPrefab;
    public GameObject pointCreation;
    public GestionNiveauPotions gestionNiveauPotions;
    public Bulles bulles;
    public Hud Hud;
    public float modificateur = 0;

    private bool isCalculating = false;
    private bool messageEnCours = false;

    public TMP_Text texteTrop;
    public TMP_Text texteModificateur;


    // C'est sans doute la partie la plus difficile et la plus complexe du code de mon jeu.


    


    // Reçoit le premier nombre choisi par le joueur
    public void RecevoirPremierNombre(float valeur)
    {
        Debug.Log("Premier nombre reçu = " + valeur);
        factor1 = valeur;
    }

    // Reçoit le deuxième nombre choisi par le joueur
    public void RecevoirDeuxiemeNombre(float valeur)
    {
        Debug.Log("Deuxieme nombre reçu = " + valeur);
        factor2 = valeur;
    }

    // Au départ, le message "PLUS GRAND QUE 100" est caché
    private void Start()
    {
        texteTrop.gameObject.SetActive(false);
    }

    // Vérifie en continu si le calcul peut être lancé
    private void Update()
    {
        int nombresDePotions = gestionNiveauPotions.listePotions.transform.childCount;

        // Si les deux nombres sont choisis, que le calcul n'est pas déjà en cours
        // et qu'il n'y a pas trop de chose sur la liste, alors on lance le calcul
        if (!isCalculating && factor1 > 0 && factor2 > 0 && nombresDePotions < 10)
        {
            StartCoroutine(Calculer());
        }

        // Affiche ou cache le modificateur selon sa valeur
        if (modificateur == 0)
        {
            texteModificateur.gameObject.SetActive(false);
        } 
        else
        {
            texteModificateur.gameObject.SetActive(true);

            if (modificateur > 0)
            {
                texteModificateur.text = $"+{modificateur}";    
            }
            else
            {
                texteModificateur.text = $"{modificateur}";
            }
        }
    }

    // Coroutine principale : fait le calcul, crée les ingrediants et lance les effets associés.


    // **** MESSAGE IMPORTANT: Le nom « listepotion » est trompeur. En réalité, il désigne la listeIngrédients du jeu et non les potions elles-mêmes. Cela due principalement à des changements de dernière minute dans mon code ;P.
    IEnumerator Calculer()
    {
        isCalculating = true;

        // Calcule le résultat final avec les deux facteurs et le modificateur
        resultat = (factor1 * factor2) + modificateur;
        Debug.Log("Résultat Final : " + resultat);

        // Si le résultat reste valide, on crée la potion
        if (resultat <= 100)
        {
            GameObject clone = Instantiate(
                IngredientPrefab,
                pointCreation.transform.position,
                pointCreation.transform.rotation
            );

            clone.GetComponent<Nombres>().factor = resultat;

            Debug.Log("Potion changed");

            float image = resultat - 1f;
            clone.GetComponent<PotionChangeur>().ChangePotion((int)image);

            // Lance les effets visuels et sonores
            gestionNiveauPotions.Smoke.GetComponent<SmokeEffect>().Smoke();
            bulles.StartTirBulle();
            Hud.AjouterMouvement();

            // Réinitialise le modificateur après le calcul
            modificateur = 0;

            // Petit délai avant de ranger les objets dans la liste
            yield return new WaitForSeconds(2.5f);

            clone.transform.SetParent(gestionNiveauPotions.listePotions, true);

            gestionNiveauPotions.potionGauche.transform.SetParent(
                gestionNiveauPotions.listePotions,
                true
            );

            gestionNiveauPotions.potionDroite.transform.SetParent(
                gestionNiveauPotions.listePotions,
                true
            );

            gestionNiveauPotions.potionGauche = null;
            gestionNiveauPotions.potionDroite = null;

            // Remet les valeurs à zéro pour préparer le prochain calcul
            factor1 = 0;
            factor2 = 0;
            modificateur = 0;

            RebuildLayout();
        }

        // Si le résultat est trop grand, on affiche un message d'erreur
        if (resultat > 100)
        {
            texteTrop.gameObject.SetActive(true);
            Invoke("MessageTemporaire", 3f);
        }

        isCalculating = false;
    }

    // Force l'interface à se réorganiser correctement après les changements
    void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(
            gestionNiveauPotions.listePotions.GetComponent<RectTransform>()
        );
    }

    // Fait disparaître le message "trop" après un délai et remet l'état du jeu à zéro
    public void MessageTemporaire()
    {
        texteTrop.gameObject.SetActive(false);

        factor1 = 0;
        factor2 = 0;

        // Remet les potions en place si elles existent encore
        if (gestionNiveauPotions.potionGauche != null)
        {
            gestionNiveauPotions.potionGauche.transform.SetParent(
                gestionNiveauPotions.listePotions,
                true
            );

            gestionNiveauPotions.potionGauche = null;
        }

        if (gestionNiveauPotions.potionDroite != null)
        {
            gestionNiveauPotions.potionDroite.transform.SetParent(
                gestionNiveauPotions.listePotions,
                true
            );

            gestionNiveauPotions.potionDroite = null;
        }
    }
}