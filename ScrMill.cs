using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationDirection
{
    Clockwise = -1,
    CounterClockwise = 1
}
public class ScrMill : MonoBehaviour
{
    float rotation = 0.0f;
    public RotationDirection rotationDirection;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().gameIsPaused)
        {
            rotation += rotationSpeed * (float)rotationDirection;
            rotation %= 360f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        }  
    }
}
