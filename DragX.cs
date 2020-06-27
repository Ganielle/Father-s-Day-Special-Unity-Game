using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragX : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private PlayButton play;
    private RectTransform rectTransform;

    bool isSlide;
    Vector2 delta, pos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        pos = rectTransform.anchoredPosition;
        isSlide = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isSlide)
            return;

        pos.x += eventData.delta.x / canvas.scaleFactor;
        rectTransform.anchoredPosition = pos;

        if (eventData.delta.x < -30)
        {
            play.rightAnswer();
            isSlide = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
