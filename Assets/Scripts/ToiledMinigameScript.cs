using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
                game.gameObject.SetActive(true);
                world.gameObject.SetActive(false);
            }
        } else {
            canvas.enabled = false;
        }
    }

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;
}
