using UnityEngine;
using System.Collections;

public class Bulles : MonoBehaviour
{
    public GameObject bullePrefab;
    public Transform pointCreation;
    public Calculateur calculateur;

    public float force = 10f;
    public float xRange = 3f;

    public float delaiEntreBulles = 0.2f;
    public GestionNiveauPotions gestionNiveauPotions;
    public int quantite;
    public AudioSource audioSource;
    public AudioClip bubbleSound;

    // Démarre la coroutine qui permet de créer plusieurs bulles
    public void StartTirBulle()
    {
        StartCoroutine(TirBulle());
    }

    // Coroutine qui crée un nombre de bulles selon le résultat du calcul
    public IEnumerator TirBulle()
    {
        int quantite = (int)calculateur.resultat;
        Debug.Log(quantite);

        // Boucle qui crée les bulles une par une avec un délai
        for (int i = 0; i < quantite; i++)
        {
            float randomX = Random.Range(-xRange, xRange);

            Vector3 NouveauPointCreation =
                pointCreation.position + new Vector3(randomX, 0f, 0f);

            Bulle(NouveauPointCreation);

            yield return new WaitForSeconds(delaiEntreBulles);
        }
    }

    // Fonction qui crée une bulle et lui applique un mouvement vers le haut
    public void Bulle(Vector3 NouveauPointCreation)
    {
        GameObject clone = Instantiate(
            bullePrefab,
            NouveauPointCreation,
            Quaternion.identity
        );

        audioSource.PlayOneShot(bubbleSound);

        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.up * force;
    }
}