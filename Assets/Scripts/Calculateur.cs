using UnityEngine;
using UnityEngine.UI;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    public float factor1 = 0;
    public float factor2 = 0;

    public GameObject PotionPrefab;
    public GameObject pointCreation;
    public GestionNiveauPotions gestionNiveauPotions;
    public Hud Hud;
    public float modificateur = 0;



    public void RecevoirPremierNombre(float valeur)
    {

        Debug.Log("Premier nombre reçu = " + valeur);
        factor1 = valeur;
        // Calculer();
    }

    public void RecevoirDeuxiemeNombre(float valeur)
    {
        Debug.Log("Deuxieme nombre reçu = " + valeur);
        factor2 = valeur;
        // Calculer();
    }


    private void Update()
    {
        if (factor1 > 0 && factor2 > 0)
        {
            Calculer();
        }
    }

    void Calculer()

    {
        resultat = (factor1 * factor2) + modificateur;
        Debug.Log("Résultat Final : " + resultat);

        if (resultat < 100)
        {


            GameObject clone = Instantiate(
                PotionPrefab,
                pointCreation.transform.position,
                pointCreation.transform.rotation,
                gestionNiveauPotions.listePotions
            );

            clone.GetComponent<Nombres>().factor = resultat;



            Debug.Log("Potion changed");
            float image = resultat - 1f;
            clone.GetComponent<PotionChangeur>().ChangePotion((int)image);


            gestionNiveauPotions.potionGauche.transform.SetParent(gestionNiveauPotions.listePotions, true);
            gestionNiveauPotions.potionDroite.transform.SetParent(gestionNiveauPotions.listePotions, true);

            gestionNiveauPotions.potionGauche = null;
            gestionNiveauPotions.potionDroite = null;

            gestionNiveauPotions.Smoke.GetComponent<SmokeEffect>().Smoke();


            Hud.AjouterMouvement();

            factor1 = 0;
            factor2 = 0;
            modificateur = 0;
            RebuildLayout();
        }
        else
        {

        }


    }


    void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(gestionNiveauPotions.listePotions.GetComponent<RectTransform>());


    }
}

