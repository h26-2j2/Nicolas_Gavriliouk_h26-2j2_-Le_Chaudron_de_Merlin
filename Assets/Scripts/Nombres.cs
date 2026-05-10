using UnityEngine;
using TMPro;
public class Nombres : MonoBehaviour
{

    public TMP_Text texteFactor;
    public float factor = 1f;
    public TMP_FontAsset LaPolice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texteFactor = GetComponentInChildren<TMP_Text>();

        texteFactor.text = $"{factor}";
        texteFactor.fontSize = 15f;
        texteFactor.font = LaPolice;

        texteFactor.fontMaterial.SetFloat(
            ShaderUtilities.ID_OutlineWidth,
            0.3f
        );

        texteFactor.fontMaterial.SetColor(
            ShaderUtilities.ID_OutlineColor,
            Color.black
        );

        texteFactor.fontMaterial.SetColor(
            ShaderUtilities.ID_UnderlayColor,
            Color.clear
        );

        texteFactor.transform.localPosition = new Vector3(0f, 0.2f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
