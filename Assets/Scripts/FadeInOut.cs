using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator fadeAnim;
    void Start()
    {
            Debug.Log("Start is running!");
        fadeAnim.SetTrigger("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
