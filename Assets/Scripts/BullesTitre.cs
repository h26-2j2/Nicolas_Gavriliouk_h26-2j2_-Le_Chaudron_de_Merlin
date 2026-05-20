using UnityEngine;

public class BullesTitre : MonoBehaviour
{
    public GameObject bulleTitrePrefab;
    public Transform pointCreation;

    public float force = 10f;
    public float xRange = 3f;

    public float delaiEntreBulles = 1.2f;

/*
Ce script fonctionne de manière similaire au précédent, mais les bulles 
sont créées automatiquement à répétition grâce à InvokeRepeating, une fonction 
que j’ai appris et qui permet d’appeler automatiquement une fonction 
après un délai de départ ET! de la répéter à intervalles réguliers. Chaque bulle 
est ensuite détruite individuellement après quelques secondes.
*/
    void Start()
    {
        InvokeRepeating("CreerBulle", 0f, delaiEntreBulles);
    }

    void CreerBulle()
    {
        float randomX = Random.Range(-xRange, xRange);

        Vector3 nouveauPointCreation =
            pointCreation.position + new Vector3(randomX, 0f, 0f);

        GameObject clone = Instantiate(
            bulleTitrePrefab,
            nouveauPointCreation,
            Quaternion.identity
        );


        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * force;
        }

        Destroy(clone, 10f);
    }
}