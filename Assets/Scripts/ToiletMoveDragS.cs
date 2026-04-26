using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider))]

public class ToiletMoveDragS : MonoBehaviour
{
    private bool hit = false;
    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        var mousePos = Mouse.current.position.ReadValue();
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, screenPoint.z));
        hit = false;
    }

    void OnMouseDrag()
    {
        if (!hit)
        {
            var mousePos = Mouse.current.position.ReadValue();
            Vector3 curScreenPoint = new Vector3(mousePos.x, mousePos.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    public void Hit()
    {
        hit = true;
    }
}