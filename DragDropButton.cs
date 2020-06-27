using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButton : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform, oldChildrenPauseMenuPos, newChildrenPauseMenuPos;

    Vector2 oldPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        oldChildrenPauseMenuPos = rectTransform;
        newChildrenPauseMenuPos = rectTransform;
        oldPos();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    private void oldPos() => oldPosition = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y);

    private void newPos() => newChildrenPauseMenuPos.localPosition = new Vector2(oldPosition.x, oldPosition.y);
}
