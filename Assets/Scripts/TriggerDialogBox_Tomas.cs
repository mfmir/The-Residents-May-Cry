using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerDialogBox_Tomas : MonoBehaviour
{
    [SerializeField] private string textToShow;
    [SerializeField] private TriggerJumpScare_Tomas enableNextJumpScareTrigger;
    [SerializeField] private TriggerDialogBox_Tomas enableNextDialogScareTrigger;
    Canvas canvas;
    bool triggered = false;
    bool finished = false;
    [SerializeField] private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        TextMeshProUGUI text = canvas.GetComponentInChildren<TextMeshProUGUI>(true);
        text.text = textToShow;
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
{
    if (triggered && !GetComponent<AudioSource>().isPlaying && !finished)
    {
        finished = true;
        HideText();
        EnableNextTrigger();
    }
}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (finished) return;
        if (GetComponent<AudioSource>().isPlaying) return;
        ShowText();
        GetComponent<AudioSource>().Play();
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
    private void EnableNextTrigger()
    {
        if (enableNextDialogScareTrigger is not null)
        {
            enableNextDialogScareTrigger.gameObject.SetActive(true);
            Debug.Log("Next enabled");
        }
        if (enableNextJumpScareTrigger is not null)
        {
            enableNextJumpScareTrigger.gameObject.SetActive(true);
            Debug.Log("Next enabled");
        }
    }
}
