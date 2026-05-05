using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GestionScene : MonoBehaviour
{
    public string sceneIntro = "";
    public string sceneJeu = "";

    public Animator anim;
 

    private void Start()
    {
    anim = GameObject.Find("FadeImage").GetComponent<Animator>();
    }
    public void DemarrerJeu()
    {

        anim.SetTrigger("Fade");

        Invoke ( "CutScene", 2);
    }
    void CutScene() {
         SceneManager.LoadScene(sceneJeu);
         anim.SetTrigger("Fade");


    }
}
