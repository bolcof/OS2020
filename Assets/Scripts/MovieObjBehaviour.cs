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
            }
        }
        else
        {
            if (dist > ExitDistance)
            {
                isPlaying = false;
                this.gameObject.GetComponent<VideoPlayer>().Stop();
            }
        }
    }
}
