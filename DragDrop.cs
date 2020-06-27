using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private PlayButton play;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform, oldChildrenPauseMenuPos, newChildrenPauseMenuPos;

    Vector2 oldPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            newPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer")
            play.rightAnswer();
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
