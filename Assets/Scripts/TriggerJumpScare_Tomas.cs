using UnityEngine;
using UnityEngine.UI;

public class TriggerJumpScare_Tomas : MonoBehaviour
{
    private RawImage lockerImageUI;
    [SerializeField] private Texture imageToShow;
    Canvas LockerImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LockerImage = GetComponentInChildren<Canvas>(true);
        lockerImageUI = LockerImage.GetComponentInChildren<RawImage>();
        lockerImageUI.texture = imageToShow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Showing image");
        LockerImage.enabled = true;
        Debug.Log("Player entered trigger!");
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            Debug.Log("Player left trigger!");
        
    }

    private void ShowImage()
    {
        
    }
}
