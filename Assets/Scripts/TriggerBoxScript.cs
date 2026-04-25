using System;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool jumpscareDone = false;
    private JumpScareScript _jumpScareScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _jumpScareScript = transform.parent.GetComponent<JumpScareScript>();
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                if (!jumpscareDone)
                {
                    _jumpScareScript.HideImage();
                    jumpscareDone = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!jumpscareDone)
        {
            Debug.Log(other.name);
            _jumpScareScript.ShowImage();
            timeRemaining = 2;
        }
    }
}
