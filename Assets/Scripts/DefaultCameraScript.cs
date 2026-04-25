using UnityEngine;

public class DefaultCameraScript : MonoBehaviour
{
    public Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
