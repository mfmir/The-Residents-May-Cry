using System;
using UnityEngine;
using UnityEngine.UI;

public class ToiledMinigameScript : MonoBehaviour
{
    private bool selected = false;
    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Canvas canvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(player.position, transform.position);
        Debug.Log(distance);
        Debug.Log(selected);

        if (distance <= interactDistance && selected)
        {
            canvas.enabled = true;
        } else {
            canvas.enabled = false;
        }
    }

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;
}
