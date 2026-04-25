using UnityEngine;

public class ToiletFinishScript : MonoBehaviour
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
        Debug.Log("Toileto finito");
        if (other.gameObject.tag == "ToiletCube")
        {
            
        }
    }
}
