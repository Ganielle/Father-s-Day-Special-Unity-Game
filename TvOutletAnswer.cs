using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TvOutletAnswer : MonoBehaviour
{
    [Header("Graphic Raycaster")]
    [SerializeField] private List<GraphicRaycaster> rayCaster;

    [Header("Values")]
    [SerializeField] private float correctConnectCount;
    public float connectCount;
    public bool isOutletTouch, isTvTouch;

    [Header("Script References")]
    [SerializeField] private PlayButton play;
    [SerializeField] private SoundManager sfx;


    private void Update()
    {
        countTimer();
        if(connectCount >= correctConnectCount)
        {
            foreach(GraphicRaycaster raycast in rayCaster)
            {
                raycast.enabled = false;

            }
            play.rightAnswer();
            connectCount = 0f;
            isOutletTouch = false;
            isTvTouch = false;
        }
    }

    private void countTimer()
    {
        if (isOutletTouch && isTvTouch)
            connectCount += 1 * Time.deltaTime;
    }
}
