using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieObjBehaviour : MonoBehaviour
{
    public float triggerDistance, ExitDistance;
    public float MaxDistance, MuteDistance;

    public bool isPlaying;

    public GameObject PlayerObj;
    public VideoPlayer inversed;

    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (!isPlaying)
        {
            if (dist < triggerDistance)
            {
                isPlaying = true;
                this.gameObject.GetComponent<VideoPlayer>().time = 0.0f;
                this.gameObject.GetComponent<VideoPlayer>().Play();
                inversed.time = 0.0f;
                inversed.Play();
            }
        }
        else
        {
            if(dist < MaxDistance)
            {
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 1.0f);
            }
            else if(dist > MuteDistance)
            {
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0.0f);
            }
            else
            {
                float tmp = (MuteDistance - dist) / (MuteDistance - MaxDistance);
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, tmp);
            }

            if (dist > ExitDistance)
            {
                isPlaying = false;
                this.gameObject.GetComponent<VideoPlayer>().time = 0.0f;
                this.gameObject.GetComponent<VideoPlayer>().Stop();
                inversed.Stop();
            }
        }
    }
}
