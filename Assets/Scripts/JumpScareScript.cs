using UnityEngine;

public class JumpScareScript : MonoBehaviour
{
    Canvas myCanvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCanvas = GetComponentInChildren<Canvas>();
        
        myCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage()
    {
        myCanvas.gameObject.SetActive(true);
    }
}
