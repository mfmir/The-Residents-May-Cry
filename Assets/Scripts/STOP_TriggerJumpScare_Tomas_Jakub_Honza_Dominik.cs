using DefaultNamespace;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class STOP_TriggerJumpScare_Tomas : MonoBehaviour
{
    private RawImage lockerImageUI;
    [SerializeField] private Texture imageToShow;
    [SerializeField] private STOP_TriggerJumpScare_Tomas enableNextJumpScareTrigger;
    [SerializeField] private TriggerDialogBox_STOP enableNextDialogScareTrigger;
    [SerializeField] private Transform player;
    Canvas LockerImage;
    bool triggered = false;
    bool finished = false;
    int time = 0;
    int time_max = 30;
    new public AudioSource audio; //jumpscareaudio
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LockerImage = GetComponentInChildren<Canvas>(true);
        lockerImageUI = LockerImage.GetComponentInChildren<RawImage>();
        lockerImageUI.texture = imageToShow;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !finished)
        {
            time++;
        }
        if (time >= time_max && !finished)
        {
            finished = true;
            HideImage();
            
        }
        if (finished && !audio.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Jumpscare();
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            Debug.Log("Player left trigger!");
        
    }

    private void ShowImage()
    {
        Debug.Log("Showing image");
        LockerImage.enabled = true;
        player.gameObject.GetComponent<FirstPersonController>().stopped = true;
    }
    public void Jumpscare()
    {
        if (finished || SecondSceneData.minigameFinished) return;
        ShowImage();
        audio.Play();
        Debug.Log("Player entered trigger!");
        triggered = true;
    }
    private void HideImage()
    {
        Debug.Log("Hiding image");
        LockerImage.enabled = false;
        EnableNextTrigger();
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
