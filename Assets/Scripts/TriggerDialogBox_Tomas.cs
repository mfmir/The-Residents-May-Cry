using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerDialogBox_Tomas : MonoBehaviour
{
    [SerializeField] private string textToShow;
    Canvas canvas;
    bool triggered = false;
    bool finished = false;
    new public AudioSource audio; //jumpscareaudio
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        TextMeshProUGUI text = canvas.GetComponentInChildren<TextMeshProUGUI>(true);
        text.text = textToShow;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
{
    if (triggered && !audio.isPlaying && !finished)
    {
        finished = true;
        HideText();
    }
}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (finished) return;
        ShowText();
        audio.Play();
        Debug.Log("Player entered trigger!");
        triggered = true;
        
    }

    private void OnTriggerExit(Collider other)
    {

            Debug.Log("Player left trigger!");
        
    }

    private void ShowText()
    {
        Debug.Log("Showing image");
        canvas.enabled = true;
    }
    private void HideText()
    {
        Debug.Log("Hiding image");
        canvas.enabled = false;
    }
}
