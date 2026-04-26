using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SecondSceneExitDoorScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text canvasText;
    private bool selected = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasText.text = "Before leaving you have to find a key.";
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(player.position, transform.position);
        
        if (distance <= interactDistance && selected)
        {
            canvas.enabled = true;
            
            if (SecondSceneData.minigameFinished)
            {
                canvasText.text = "Press <E> to open";
            }
            
            
            if (SecondSceneData.minigameFinished && Keyboard.current.eKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("LaserMazeIntegration");
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;
}
