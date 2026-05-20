using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GestionScene : MonoBehaviour
{
    

    private string sceneLoad;
    public Animator anim;

    // Au début, récupère l'animateur et lance l'animation de FadeOut
    private void Start()
    {
        anim = GameObject.Find("FadeInOut").GetComponent<Animator>();
        anim.SetTrigger("FadeOut");
    }

    // J'ai trouvé une méthode plus efficace pour changer de scène : au lieu d'ajouter des variables et de les associer à une chaîne de caractères pour chaque nivbeau, je peux simplement écrire la chaîne correspondant au niveau souhaité en modifiant la valeur du paramètre de la fonction « DemmarerJeu » dans l'inspecteur. Cela facilite l'association de chaque bouton à une scène différente :)
    public void DemarrerJeu(string sceneNom)
    {
        // Sauvegarde le nom de la scène à charger
        sceneLoad = sceneNom;

        // Lance l'animation de FadeIn avant le changement de scène
        anim.SetTrigger("FadeIn");

        Debug.Log($"current scene: {sceneLoad}");

        // Attend 1 seconde avant de changer de scène
        Invoke("CutScene", 1);
    }

    // Change la scène puis relance le FadeOut
    void CutScene()
    {
        SceneManager.LoadScene(sceneLoad);
        anim.SetTrigger("FadeOut");
    }
}