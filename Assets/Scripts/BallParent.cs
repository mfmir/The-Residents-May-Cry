using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class BallParent : MonoBehaviour
{
    public int myNumber;
    public AudioSource audio;
    private bool selected = false;
    

    protected void setMyNumber(int number)
    {
        myNumber = number;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            CallParentThatIWasPressed();
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void CallParentThatIWasPressed()
    {
        audio.Play();
        transform.parent.GetComponent<PapaBallScript>().childPressed(myNumber);
        
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
    
    private void OnMouseDown()
    {
        CallParentThatIWasPressed();
    }

    private void OnMouseEnter()
    {
        selected = true;
    }

    private void OnMouseExit()
    {
        selected = false;
    }
}