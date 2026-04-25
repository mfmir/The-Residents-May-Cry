using System;
using UnityEngine;

public class LaserScript : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sorry you got hit!");
            var material = GetComponentInParent<LaserMazeScript>().onLaserTouchedMaterial;
            Debug.Log(material);
            var currentRenderer = GetComponent<Renderer>();
            currentRenderer.material = material;
            // TODO: something similar to Destroy(other.gameObject);
        }
    }
}
