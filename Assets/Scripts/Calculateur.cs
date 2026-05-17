using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    public float factor1 = 0;
    public float factor2 = 0;

    public GameObject PotionPrefab;
    public GameObject pointCreation;
    public GestionNiveauPotions gestionNiveauPotions;
    public Bulles bulles;
    public Hud Hud;
    public float modificateur = 0;

    private bool isCalculating = false;

    public void RecevoirPremierNombre(float valeur)
    {
        Debug.Log("Premier nombre reçu = " + valeur);
        factor1 = valeur;
    }

    public void RecevoirDeuxiemeNombre(float valeur)
    {
        Debug.Log("Deuxieme nombre reçu = " + valeur);
        factor2 = valeur;
    }

    private void Update()
    {
        int nombresDePotions = gestionNiveauPotions.listePotions.transform.childCount;

        if (!isCalculating && factor1 > 0 && factor2 > 0 && nombresDePotions < 10)
        {
            StartCoroutine(Calculer());
        }
    }

    IEnumerator Calculer()
    {
        isCalculating = true;

        resultat = (factor1 * factor2) + modificateur;
        Debug.Log("Résultat Final : " + resultat);

        if (resultat <= 100)
        {
            GameObject clone = Instantiate(
                PotionPrefab,
                pointCreation.transform.position,
                pointCreation.transform.rotation
            );

            clone.GetComponent<Nombres>().factor = resultat;

            Debug.Log("Potion changed");

            float image = resultat - 1f;
            clone.GetComponent<PotionChangeur>().ChangePotion((int)image);

            gestionNiveauPotions.Smoke.GetComponent<SmokeEffect>().Smoke();
            bulles.StartTirBulle();

            yield return new WaitForSeconds(3f);

            clone.transform.SetParent(gestionNiveauPotions.listePotions,
                true);

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

            Hud.AjouterMouvement();

            factor1 = 0;
            factor2 = 0;
            modificateur = 0;

            RebuildLayout();
        }
        else
        {
            Debug.Log("too much");
        }

        isCalculating = false;
    }

    void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(
            gestionNiveauPotions.listePotions.GetComponent<RectTransform>()
        );
    }
}