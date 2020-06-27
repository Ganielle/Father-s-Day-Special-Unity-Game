using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{
    [Header("Videos")]
    [SerializeField] private VideoClip[] videoGreetings;
    [SerializeField] private UnityEngine.Video.VideoPlayer videoImage;

    [Header("Script Reference")]
    [SerializeField] private PlayButton play;

    private void OnEnable()
    {
        videoImage.clip = videoGreetings[play.videoIndex];
        play.videoIndex++;
    }
}
