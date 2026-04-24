using UnityEngine;

public class PapaBallScript : MonoBehaviour
{
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

    public void childPressed(int what)
    {
        Debug.Log("Child pressed " + what);
    }
}
