using UnityEngine;
using TMPro;

public class TriggerDialogBoxMid3rdScene : MonoBehaviour
{
    [SerializeField] private string textToShow;
    [SerializeField] private TriggerJumpScare_Tomas enableNextJumpScareTrigger;
    [SerializeField] private TriggerDialogBox_Tomas enableNextDialogScareTrigger;
    Canvas canvas;
    bool triggered = false;
    bool finished = false;

    public Vector3 playerSpawnPosition;
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
        EnableNextTrigger();
    }
}
    private static void MovePlayer(Collider playerCollision, Vector3 position)
    {
        var controller = playerCollision.GetComponent<CharacterController>();
        controller.enabled = false;
        controller.transform.position = position;
        controller.enabled = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (finished) return;
        if (audio.isPlaying) return;
        ShowText();
        audio.Play();
        Debug.Log("Player entered trigger! He is supposed to get moved");
        
        triggered = true;
        MovePlayer(other, playerSpawnPosition);
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
