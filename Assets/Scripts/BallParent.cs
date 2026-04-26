using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class BallParent : MonoBehaviour
{
    public int myNumber;
    new public AudioSource audio;
    private bool selected = false;
    Canvas canvas;
    private PapaBallScript parent;

    [SerializeField] private Transform player;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Canvas interactableText;

    protected void setMyNumber(int number)
    {
        myNumber = number;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (selected && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            
        }*/

        float distance = Vector3.Distance(player.position, transform.position);
        //show press E
        if (distance <= interactDistance && selected)
        {
            interactableText.enabled = true;
        }
        else interactableText.enabled = false;
        // If player is close and presses E → show
        if (distance <= interactDistance && Keyboard.current.eKey.wasPressedThisFrame  && selected)
        {
            CallParentThatIWasPressed();
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        canvas = GetComponentInChildren<Canvas>(true);
        TextMeshProUGUI text = canvas.GetComponentInChildren<TextMeshProUGUI>(true);
        text.text = myNumber.ToString();
        parent = transform.parent.GetComponent<PapaBallScript>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void CallParentThatIWasPressed()
    {
        audio.PlayOneShot(audio.clip);
        parent.childPressed(myNumber);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CallParentThatIWasPressed();
            
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            
            if (player != null)
            {
                player.Jump(25.0f);
            }
        }
    }
    
    /*private void OnMouseDown()
    {
        CallParentThatIWasPressed();
    }*/

    private void OnMouseEnter()
    {
        selected = true;
    }

    private void OnMouseExit()
    {
        selected = false;
    }
}