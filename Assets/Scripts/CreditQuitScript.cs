using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreditQuitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
        #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
        }
    }
}
