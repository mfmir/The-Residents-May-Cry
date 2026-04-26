using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorWithoutCOnditionScript : MonoBehaviour
{
    [SerializeField] private Canvas doorLockedCanvas;
    [SerializeField] private Canvas doorUnlockedCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private string sceneName;


    private bool lockedStatus = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorLockedCanvas.enabled = false;
        doorUnlockedCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //show press E
        lockedStatus = false;
        if (lockedStatus)
        {
            if (distance <= interactDistance  && selected)
            {
                doorLockedCanvas.enabled = true;
            }
            else doorLockedCanvas.enabled = false;
        }
        else 
        {
            if (distance <= interactDistance  && selected)
            {
                doorUnlockedCanvas.enabled = true;
            }
            else doorUnlockedCanvas.enabled = false;
        }

        if (distance <= interactDistance && Keyboard.current.eKey.wasPressedThisFrame && !lockedStatus && selected)
        {
            SceneManager.LoadScene(sceneName);
        }
    }


    private bool selected = false;

    private void OnMouseEnter() => selected = true;
    private void OnMouseExit() => selected = false;
}
