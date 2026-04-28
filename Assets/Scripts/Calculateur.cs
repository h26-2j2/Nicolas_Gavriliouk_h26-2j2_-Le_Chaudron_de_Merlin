using UnityEngine;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    private float factor1 = 0;
    private float factor2 = 0;

    public GameObject PotionPrefab;
    public GameObject pointCreation;  

    Transform ListePotions;

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
   
        ListePotions = GameObject.Find("ListePotions").transform;
        GameObject clone = Instantiate(PotionPrefab,pointCreation.transform.position, pointCreation.transform.rotation, ListePotions);


 
        factor1 = 0;
        factor2 = 0;
        clone.GetComponent<Nombres>().factor = resultat;
        // Debug.Log("The number of the prefab is", factor );
    } 
    }
    
}

    