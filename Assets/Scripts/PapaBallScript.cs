using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PapaBallScript : MonoBehaviour
{
    private int[] secret_code = new[] { 2, 1, 3 };
    private bool isAnswered = false;
    Queue<int> active = new Queue<int>();
    
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
            isAnswered = true;
        };
    }
    public bool IsAnswered()
    {
        return isAnswered;
    }

    public void childPressed(int what)
    {
        Debug.Log("Child pressed " + what);
        active.Enqueue(what);
        
        GotTheAnswer();
    }
}
