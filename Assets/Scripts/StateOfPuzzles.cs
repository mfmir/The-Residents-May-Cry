using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class StateOfPuzzles : MonoBehaviour
{

    [SerializeField] private PapaBallScript puzzle1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ballScript = 
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzle1.IsCompleted())
        {
            SHowCube();
        }
    }

    void SHowCube()
    {
        MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
        renderer.enabled = true;
    }
}
