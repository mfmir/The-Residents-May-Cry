using System;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private Vector3 initialPos = new Vector3(3.6f, 3.74f, 0.2f);
    [SerializeField] new private AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //udio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cube touched");
        if (other.gameObject.tag == "ToiletCube")
        {
            var otherPos = other.GetComponent<Transform>();
            var otherScript = other.GetComponent<ToiletMoveDragS>();
            otherPos.position = initialPos;
            otherScript.Hit();
            audio.Play();
        }
    }
}
