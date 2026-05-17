using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GestionScene : MonoBehaviour
{

    // public static GameObject copieUnique;
    public string sceneIntro = "";
    public string sceneJeu = "";

    private string sceneLoad;
    public Animator anim;

// void Awake()
//     {
//         if (copieUnique == null)
//         {
//             copieUnique = this.gameObject;
//             DontDestroyOnLoad(this.gameObject);
//         }
//         else
//         {
//             Destroy(this.gameObject);
//         }
//     }

    //  private void Awake() {
        
    // }

    private void Start()
    {
        anim = GameObject.Find("FadeInOut").GetComponent<Animator>();
        anim.SetTrigger("FadeOut");
    }
    public void DemarrerJeu(string sceneNom)
    {
        sceneLoad = sceneNom;
        anim.SetTrigger("FadeIn");
        Debug.Log($"current scene: {sceneLoad}");
        Invoke("CutScene", 1);
    }
    void CutScene()
    {
        SceneManager.LoadScene(sceneLoad);
        anim.SetTrigger("FadeOut");
    }
}
