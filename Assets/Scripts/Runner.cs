using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public GameObject origin;
    private float angleX = 0.2f;
    public float speed;

    public float MaxDistance, MuteDistance;

    void Start()
    {
        
    }
    
    void Update()
    {
        angleX += speed;
        if (angleX >= 179.9f) { angleX = 179.9f; speed *= -1; }
        else if (angleX <= 0.1f) { angleX = 0.1f; speed *= -1; }
        origin.transform.localRotation = Quaternion.Euler(new Vector3(angleX, 0.0f, 0.0f));
    }
}
