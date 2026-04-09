using UnityEngine;

public class Calculateur : MonoBehaviour
{
    public float resultat;

    private float factor1;
    private float factor2;

    public void RecevoirPremierNombre(float valeur)
    {
        factor1 = valeur;
        Calculer();
    }

    public void RecevoirDeuxiemeNombre(float valeur)
    {
        factor2 = valeur;
        Calculer();
    }



    

    void Calculer()
    {
        resultat = factor1 * factor2;
        Debug.Log("Résultat : " + resultat);
    }
}