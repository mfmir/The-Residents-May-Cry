using DefaultNamespace;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerDialogBox_STOP : MonoBehaviour
{
    [SerializeField] private string textToShow;
    [SerializeField] private STOP_TriggerJumpScare_Tomas enableNextJumpScareTrigger;
    [SerializeField] private TriggerDialogBox_STOP enableNextDialogScareTrigger;
    [SerializeField] private Transform player;
    [SerializeField] private bool PlayAfterSecondPuzzle;
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

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    // Update is called once per frame
    void Update()
{
    if (triggered && !audio.isPlaying && !finished)
    {
        finished = true;
        HideText();
        gameObject.SetActive(false);
    }
}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (finished) return;
        if (audio.isPlaying) return;
        if (SecondSceneData.minigameFinished && !PlayAfterSecondPuzzle) return;
        
        ShowText();
        audio.Play();
        Debug.Log("Player entered trigger!");
        
        EnableNextTrigger();
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {

            Debug.Log("Player left trigger!");
        
    }

    private void ShowText()
    {
        Debug.Log("Showing image");
        canvas = GetComponentInChildren<Canvas>(true);
        canvas.enabled = true;
        player.gameObject.GetComponent<FirstPersonController>().stopped = true;
    }
    private void HideText()
    {
        Debug.Log("Hiding image");
        canvas.enabled = false;
        player.gameObject.GetComponent<FirstPersonController>().stopped = false;
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
