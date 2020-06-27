using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TvOutletTouch : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private TvOutletAnswer tvOutlet;
    [SerializeField] private SoundManager sfx;
    [SerializeField] private bool isOutlet;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isOutlet)
        {
            tvOutlet.isOutletTouch = true;
            sfx.PlayElectricitySound();
        }
        else
        {
            tvOutlet.isTvTouch = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isOutlet)
        {
            tvOutlet.isOutletTouch = false;
            sfx.clearPlayElectrictySound();
        }
        else
        {
            tvOutlet.isOutletTouch = false;
        }
    }
}
