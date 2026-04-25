using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
