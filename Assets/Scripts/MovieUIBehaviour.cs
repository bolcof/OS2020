using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MovieUIBehaviour : MonoBehaviour
{
    public float triggerDistance, exitDistance, dist;

    public bool isPlaying, isReady, isBroken;
    public float playTime;

    public GameObject PlayerObj;
    public VideoPlayer VplayerObj;

    public RawImage Rimg;
    public Button closebtn;

    public GameObject before, after;

    public float delay;
    public float stayTime = 0.0f;

    void Update()
    {
        dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (dist > exitDistance && !isReady)
        {
            Debug.Log("exit");
            isReady = true;
        }

        if (!isPlaying && isReady)
        {
            if (dist < triggerDistance)
            {
                stayTime += Time.deltaTime;
                if(stayTime >= delay){
                    startMovie();
                }
            }else{
                stayTime = 0.0f;
            }
        }
        else
        {
            playTime += Time.deltaTime;
            if (playTime >= 165.0f)
            {
                close();
            }
        }
    }

    public void startMovie(){
        Rimg.enabled = true;
        closebtn.gameObject.SetActive(true);
        isPlaying = true;
        isReady = false;
        playTime = 0.0f;
        VplayerObj.Play();
        PlayerObj.GetComponent<MoveScript>().isActive = false;
    }

    public void close()
    {
        Debug.Log("close");
        Rimg.enabled = false;
        closebtn.gameObject.SetActive(false);
        isPlaying = false;
        VplayerObj.time = 0.0f;
        VplayerObj.Stop();
        PlayerObj.GetComponent<MoveScript>().isActive = true;
        playTime = 0.0f;

        isBroken = true;
        after.SetActive(true);
        before.SetActive(false);
    }
}
