using UnityEngine;
using UnityEngine.UI;

public class Calculateur : MonoBehaviour
{
    public float resultat;
    
    private float factor1 = 0;
    private float factor2 = 0;

    public GameObject PotionPrefab;
    public GameObject pointCreation;  
    public GestionNiveauPotions gestionNiveauPotions;


    public void RecevoirPremierNombre(float valeur)
    {

          Debug.Log("Premier nombre reçu = " + valeur);
        factor1 = valeur;
        Calculer();
    }

    public void RecevoirDeuxiemeNombre(float valeur)
    {
          Debug.Log("Deuxieme nombre reçu = " + valeur);
        factor2 = valeur;
        Calculer();
    }




    

    void Calculer()
    {

         Debug.Log("factor1 actuel = " + factor1);
        Debug.Log("factor2 actuel = " + factor2);

        resultat = factor1 * factor2;
        Debug.Log("Résultat Final : " + resultat);

        
    }

    private void Update() {
        
        if (factor1 > 0 && factor2 > 0) 
    {
   
        
        GameObject clone = Instantiate(PotionPrefab,pointCreation.transform.position, pointCreation.transform.rotation, gestionNiveauPotions.listePotions);
       
        
         transform.SetParent(gestionNiveauPotions.listePotions, true);
 
        factor1 = 0;
        factor2 = 0;

        gestionNiveauPotions.potionGauche.transform.SetParent(gestionNiveauPotions.listePotions, true);
        gestionNiveauPotions.potionDroite.transform.SetParent(gestionNiveauPotions.listePotions, true);
        gestionNiveauPotions.potionGauche = null;
        gestionNiveauPotions.potionDroite = null;
        LayoutRebuilder.ForceRebuildLayoutImmediate(gestionNiveauPotions.listePotions.GetComponent<RectTransform>());

        clone.GetComponent<Nombres>().factor = resultat;
        // Debug.Log("The number of the prefab is", factor );

    } 
    }
    
}

    