using UnityEngine;

public class Detector : MonoBehaviour
{

     public GestionNiveauPotions gestionNiveauPotions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        float modifier = other.GetComponent<DragFrog>().modifier;
        // Debug.Log(other.GetComponent<DragFrog>().modifier);
        Calculateur calculateur = FindObjectOfType<Calculateur>();
        calculateur.modificateur = modifier;
        gestionNiveauPotions.Smoke.GetComponent<SmokeEffect>().Smoke();

        Destroy(other.gameObject);
        // Debug.Log(other.name + " entered the box");
    }
}
