using System;
using StarterAssets;
using UnityEngine;

public class JumpingBoxScript : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player"))
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>();

            Debug.Log("Tag compared");
            if (player != null)
            {
                Debug.Log("Jumping");
                player.Jump(100.0f);
            }
        }
    }
}
