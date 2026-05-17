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

    // private bool bullesCreees = false;
    public GestionNiveauPotions gestionNiveauPotions;
    public GameObject potionGauche;
    public GameObject potionDroite;

    public int quantite;

    public AudioSource audioSource;
    public AudioClip bubbleSound;
     public void StartTirBulle()
    {
        StartCoroutine(TirBulle());
    }
    public IEnumerator TirBulle()
    {
        int quantite = (int)calculateur.resultat;
        Debug.Log(quantite);

        for (int i = 0; i < quantite; i++)
        {
            float randomX = Random.Range(-xRange, xRange);

            Vector3 NouveauPointCreation =
                pointCreation.position + new Vector3(randomX, 0f, 0f);

            Bulle(NouveauPointCreation);
            // Debug.Log(quantite);
            
            yield return new WaitForSeconds(delaiEntreBulles);
        }

    }

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

        // Invoke("DestroyBulle", 10f);
        
    }

    // public void DestroyBulle()
    // {
    //     GameObject[] bulles = GameObject.FindGameObjectsWithTag("Bulle");

    // foreach(GameObject bulle in bulles)
    // {
    //     Destroy(bulle);
    // }
    // }
}