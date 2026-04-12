using UnityEngine;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    private float factor1 = 0;
    private float factor2 = 0;

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
}