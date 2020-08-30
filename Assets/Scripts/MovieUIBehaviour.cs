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
    public Button closebtn;

    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (dist > exitDistance && !isReady)
        {
            Debug.Log("exit");
            isReady = true;
        }

        if (!isPlaying && isReady)
        {
            if (dist < triggerDistance)
            {
                Debug.Log("start");
                Rimg.enabled = true;
                closebtn.gameObject.SetActive(true);
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
                Debug.Log("end");
                Rimg.enabled = false;
                closebtn.gameObject.SetActive(false);
                isPlaying = false;
                VplayerObj.Stop();
                VplayerObj.time = 0.0f;
                PlayerObj.GetComponent<MoveScript>().isActive = true;
            }
        }
    }

    public void close()
    {
        Debug.Log("close");
        Rimg.enabled = false;
        closebtn.gameObject.SetActive(false);
        isPlaying = false;
        VplayerObj.Stop();
        VplayerObj.time = 0.0f;
        PlayerObj.GetComponent<MoveScript>().isActive = true;
    }
}
