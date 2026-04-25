using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MazeCenteredScript : MonoBehaviour
{
    public float rotationSpeed;
    public int mazeRotatingTime;
    public int rotatingCycleLength;
    private int _mazeRotatingCounter = 0;

    public int laserAppearanceCycleCount;
    public int laserDisappearanceCycleCount;
    private bool _lasersAppearing = true;
    private int _laserAppearanceCycleCounter = 0;

    private GameObject[] _childrenLasers;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _childrenLasers = GetComponentsInChildren<Transform>().Where(child => child.CompareTag("Laser")).Select(child => child.gameObject).ToArray();
    }

    private void MakeLasersAppear()
    {
        foreach (var laser in _childrenLasers)
            laser.gameObject.SetActive(true);
    }

    private void MakeLasersDisappear()
    {
        foreach (var laser in _childrenLasers)
            laser.gameObject.SetActive(false);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (_mazeRotatingCounter <= mazeRotatingTime)
            transform.Rotate(Vector3.right * rotationSpeed);
        
        _mazeRotatingCounter++;
        if (_mazeRotatingCounter >= rotatingCycleLength)
        {
            _mazeRotatingCounter = 0;
            _laserAppearanceCycleCounter++; 
        }

        if (_laserAppearanceCycleCounter >= laserAppearanceCycleCount)
        {
            if (_lasersAppearing)
            {
                Debug.Log("Lasers are disappearing");
                MakeLasersDisappear();
                _lasersAppearing = false;
            }

            if (_laserAppearanceCycleCounter >= laserDisappearanceCycleCount + laserAppearanceCycleCount)
            {
                Debug.Log("Lasers are appearing");
                _laserAppearanceCycleCounter = 0;
                MakeLasersAppear();
                _lasersAppearing = true;
            }
        }
    }
}
