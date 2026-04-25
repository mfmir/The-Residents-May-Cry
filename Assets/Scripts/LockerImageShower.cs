using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LockerImageShower : MonoBehaviour
{


    private bool Image_shown = false;

    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;

    private RawImage lockerImageUI;
    [SerializeField] private Texture imageToShow;
    [SerializeField] private Canvas LockerImage;
    [SerializeField] private Canvas interactableText;
    [SerializeField] private AudioSource openLockerAudio;
    [SerializeField] private AudioSource closeLockerAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    lockerImageUI = LockerImage.GetComponentInChildren<RawImage>();
    lockerImageUI.texture = imageToShow;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //show press E
        if (distance <= interactDistance && !Image_shown && selected)
        {
            interactableText.enabled = true;
        }
        else interactableText.enabled = false;
        // If player is close and presses E → show
        if (distance <= interactDistance && Keyboard.current.eKey.wasPressedThisFrame && !Image_shown && selected)
        {
            ShowLockerImage();
        }

        // If player walks away → hide
        if (distance > interactDistance && Image_shown)
        {
            HideLockerImage();
        }

        // Optional: ESC to close
        if (Keyboard.current.escapeKey.wasPressedThisFrame && Image_shown)
        {
            HideLockerImage();
        }
    }

    private void ShowLockerImage()
    {
        Debug.Log("Showing image");
        LockerImage.enabled = true;
        Image_shown = true;
        openLockerAudio.Play();      
    }
    private void HideLockerImage()
    {
        LockerImage.enabled = false;
        Image_shown = false;
        Debug.Log("HIding image");
        closeLockerAudio.Play();
    }

    private bool selected = false;

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;

    
}
