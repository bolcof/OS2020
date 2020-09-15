﻿using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoLoader : MonoBehaviour
{
    [SerializeField]
    private string relativePath;

    void Start()
    {
        VideoPlayer player = this.gameObject.GetComponent<VideoPlayer>();
        player.source = VideoSource.Url;
        player.url = Application.streamingAssetsPath + "/" + relativePath;
        player.prepareCompleted += PrepareCompleted;
        player.Prepare();
    }
    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
    }
}