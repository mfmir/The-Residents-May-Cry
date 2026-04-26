using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ToiledMinigameScript : MonoBehaviour
{
    private bool selected = false;
    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform world;
    [SerializeField] private Transform game;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false;
        game.gameObject.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (SecondSceneData.loadData)
        {
            player.position = SecondSceneData.position;
            player.rotation = SecondSceneData.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance && selected)
        {
            canvas.enabled = true;

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                SecondSceneData.position = player.position;
                SecondSceneData.rotation = player.rotation;
                SecondSceneData.loadData = true;
                SecondSceneData.minigameFinished = true;
                
                SceneManager.LoadScene("Toilet");
            }
        } else {
            canvas.enabled = false;
        }
    }

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;
}
