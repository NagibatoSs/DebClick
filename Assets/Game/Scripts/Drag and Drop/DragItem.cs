using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool IsDraggable { get; private set; }
    public bool isJustMove;
    private float _startTime;
    private float _endTime;

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDraggable || !eventData.pointerCurrentRaycast.isValid) return;
        var position = eventData.pointerCurrentRaycast.worldPosition;
        var posV3 = new Vector3(position.x, position.y, transform.position.z);
        var delta = posV3 - transform.position;
        transform.position += delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTime = Time.time;
        isJustMove = true;
        IsDraggable = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _endTime = Time.time;
        if ((_endTime - _startTime) < 0.2f) isJustMove = false;
        if (!IsDraggable) return;
        IsDraggable = false;
    }
}
