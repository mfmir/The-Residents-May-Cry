using UnityEngine;
using UnityEngine.InputSystem;

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