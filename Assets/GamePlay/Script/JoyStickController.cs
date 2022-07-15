using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public float maxDisplacement = 200;
    Vector2 startPos;
    Transform handle;

    public static float Horizontal = 0, Vertical = 0;

    public void Start()
    {
        handle = transform.GetChild(0);
        startPos = handle.position;
    }

    public void UpdateHandle(Vector2 pos)
    {
        var delta = pos - startPos;
        delta = Vector2.ClampMagnitude(delta, maxDisplacement);
        handle.position = startPos + delta;
        Horizontal = delta.x / maxDisplacement;
        Vertical = delta.y / maxDisplacement;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateHandle(eventData.position);
    }
    public void OnDrag(PointerEventData eventData)
    {
        UpdateHandle(eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        UpdateHandle(startPos);
    }
}
