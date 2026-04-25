using System;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Material onLaserTouchedMaterial;
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
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sorry you got hit!");
            var currentRenderer = GetComponent<Renderer>();
            currentRenderer.material = onLaserTouchedMaterial;
            // TODO: something similar to Destroy(other.gameObject);
        }
    }
}
