using DefaultNamespace;
using UnityEngine;

public class SecondScene_AfterPuzzle_EnableTrigger : MonoBehaviour
{
    bool finished_script = false;
    [SerializeField] private TriggerDialogBox_STOP enableNextDialogScareTrigger;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!finished_script && SecondSceneData.minigameFinished)
        {
            enableNextDialogScareTrigger.gameObject.SetActive(true);
            finished_script = true;
            Debug.Log("Enableling final box_Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished_script && SecondSceneData.minigameFinished)
        {
            enableNextDialogScareTrigger.gameObject.SetActive(true);
            finished_script = true;
            //gameObject.SetActive(false);
            Debug.Log("Enableling final box_Update");
        }
    }
}
