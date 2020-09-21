﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class KasashimaBehaviour : MonoBehaviour
{
    public float triggerDist_S, exitDist_S;
    public float triggerDist_M, exitDist_M, dist;

    public bool isPlayingSound, isPlayingMovie, isReady;
    public float playTime;

    public float MaxDistance, MuteDistance;

    public GameObject PlayerObj;

    public VideoPlayer SplayerObj;
    public VideoPlayer VplayerObj;

    public RawImage Rimg;

    public float delay;
    public float stayTime = 0.0f;
    public float lockTime;

    void Update()
    {
        dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);

        if (!isPlayingSound)
        {
            if (dist < triggerDist_S && !isPlayingMovie)
            {
                isPlayingSound = true;
                this.gameObject.GetComponent<VideoPlayer>().time = 0.0f;
                this.gameObject.GetComponent<VideoPlayer>().Play();
            }
        }
        else
        {
            if (dist < MaxDistance)
            {
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 1.0f);
            }
            else if (dist > MuteDistance)
            {
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0.0f);
            }
            else
            {
                float tmp = (MuteDistance - dist) / (MuteDistance - MaxDistance);
                this.gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, tmp);
            }

            if (dist > exitDist_S)
            {
                isPlayingSound = false;
                this.gameObject.GetComponent<VideoPlayer>().Stop();
            }
        }


        if (dist > exitDist_M && !isReady)
        {
            Debug.Log("exit");
            isReady = true;
        }

        if (!isPlayingMovie && isReady)
        {
            if (dist < triggerDist_M)
            {
                stayTime += Time.deltaTime;
                if (stayTime >= delay)
                {
                    startMovie();
                    isPlayingSound = false;
                    this.gameObject.GetComponent<VideoPlayer>().Stop();
                }
            }
            else
            {
                stayTime = 0.0f;
            }
        }
        else
        {
            playTime += Time.deltaTime;
            if (playTime >= lockTime)
            {
                close();
            }
        }
    }

    public void startMovie()
    {
        Rimg.enabled = true;
        isPlayingMovie = true;
        isReady = false;
        playTime = 0.0f;
        VplayerObj.Play();
        PlayerObj.GetComponent<MoveScript>().isActive = false;
    }

    public void close()
    {
        Debug.Log("close");
        Rimg.enabled = false;
        isPlayingMovie = false;
        VplayerObj.Stop();
        VplayerObj.time = 0.0f;
        PlayerObj.GetComponent<MoveScript>().isActive = true;
        playTime = 0.0f;
    }
}
