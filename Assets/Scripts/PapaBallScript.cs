using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PapaBallScript : MonoBehaviour, IWinCondition
{
    private int[] secret_code = new[] { 2, 1, 3 };
    private bool done = false;
    Queue<int> active = new Queue<int>();
    [SerializeField] private TriggerDialogBox_STOP enableNextDialogScareTrigger;
    new public AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            //sDebug.Log(child.name);
        }
    }

    private void GotTheAnswer()
    {
        while (active.Count > secret_code.Length)
        {
            active.Dequeue();
        }
        
        if (active.SequenceEqual(secret_code))
        {
            Debug.Log("You got the answer!");
            enableNextDialogScareTrigger.gameObject.SetActive(true);
            audio.Play();
            done = true;
        };
    }
    public bool IsCompleted()
    {
        return done;
    }

    public void childPressed(int what)
    {
        Debug.Log("Child pressed " + what);
        active.Enqueue(what);
        
        GotTheAnswer();
    }
}
