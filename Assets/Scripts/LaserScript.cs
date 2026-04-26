using System;
using System.Transactions;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Vector3 spawnPoint;
    public Material onLaserTouchedMaterial;
    private AudioSource _playerGotHitSequence;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerGotHitSequence = GetComponent<AudioSource>();
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
            
            _playerGotHitSequence.Play();
            MovePlayer(other, spawnPoint);
        }
    }
}
