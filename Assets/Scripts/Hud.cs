using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public int cible = 0;
    public int move = 0;

    public TMP_Text texteCible;
    public TMP_Text texteMove;
    public TMP_Text texteReussi;

    public Calculateur calculateur;

    public float resultat;

    public GameObject VictoireCanvas;

    void Start()
    {
        VictoireCanvas.SetActive(false);
        texteMove.text = $"Coups: {move}";
        texteCible.text = $"Cible: {cible}";
    }
    public void AjouterMouvement()
    {
        move++;

        texteMove.text = $"Coups: {move}";
    }
    private void Update()
    {
        resultat = calculateur.resultat;

        if (resultat == cible)
        {
            Debug.Log("Victoire");
            // Debugger();
            VictoireCanvas.SetActive(true);
            texteReussi.text = $"Bravo!  Tu as réussi ce niveau en {move} coups.";
        }


    }
}