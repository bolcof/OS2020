using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MovieUIBehaviour : MonoBehaviour
{
    public float triggerDistance, exitDistance;

    public bool isPlaying, isReady;
    public float playTime;

    public GameObject PlayerObj;
    public VideoPlayer VplayerObj;
    public RawImage Rimg;

    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (!isPlaying && isReady)
        {
            if (dist < triggerDistance)
            {
                Rimg.enabled = true;
                isPlaying = true;
                isReady = false;
                playTime = 0.0f;
                VplayerObj.time = 0.0f;
                VplayerObj.Play();
                PlayerObj.GetComponent<MoveScript>().isActive = false;
            }
        }
        else
        {
            playTime += Time.deltaTime;
            if (playTime >= 15.0f)
            {
                Rimg.enabled = false;
                isPlaying = false;
                VplayerObj.Stop();
                VplayerObj.time = 0.0f;
                PlayerObj.GetComponent<MoveScript>().isActive = true;
            }
        }

        if(dist > exitDistance)
        {
            isReady = true;
        }
    }
}
