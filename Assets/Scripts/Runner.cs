using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Runner : MonoBehaviour
{
    public GameObject origin;
    private float angleX = 0.2f;
    public float speed;

    public float MaxDistance, MuteDistance;

    public VideoPlayer soundHolder;
    public GameObject PlayerObj;
    
    void Update()
    {
        angleX += speed;
        if (angleX >= 179.9f) { angleX = 179.9f; speed *= -1; }
        else if (angleX <= 0.1f) { angleX = 0.1f; speed *= -1; }
        origin.transform.localRotation = Quaternion.Euler(new Vector3(angleX, 0.0f, 0.0f));

        float dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (dist < MaxDistance)
        {
            //soundHolder.SetDirectAudioVolume(0, 1.0f);
        }
        else if (dist > MuteDistance)
        {
            //soundHolder.SetDirectAudioVolume(0, 0.0f);
        }
        else
        {
            float tmp = (MuteDistance - dist) / (MuteDistance - MaxDistance);
            //soundHolder.SetDirectAudioVolume(0, tmp);
        }
    }
}
