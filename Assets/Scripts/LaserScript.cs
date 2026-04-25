using System;
using System.Transactions;
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

    private void MovePlayer(Collider playerCollision, Vector3 position)
    {
        var controller = playerCollision.GetComponent<CharacterController>();
        controller.enabled = false;
        controller.transform.position = position;
        controller.enabled = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sorry you got hit!");
            var currentRenderer = GetComponent<Renderer>();
            currentRenderer.material = onLaserTouchedMaterial;
            Debug.Log(other.transform.parent);
            
            MovePlayer(other, new Vector3(-68, -3.5f, -230.5f));
        }
    }
}
