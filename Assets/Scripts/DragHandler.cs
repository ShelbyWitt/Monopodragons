//DragHandler.cs
// Handler for dragging the panel
using UnityEngine.EventSystems;
using UnityEngine;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 offset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = eventData.position - new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = eventData.position - offset;
    }
}