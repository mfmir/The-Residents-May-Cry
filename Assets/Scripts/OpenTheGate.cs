using UnityEngine;

public class OpenTheGate : MonoBehaviour
{
    public float openingSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.down * openingSpeed * Time.deltaTime;
        if (gameObject.transform.position.y <= -18)
        {
            Destroy(gameObject);
        }
    }
}
