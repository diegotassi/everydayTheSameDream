using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DirectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float dir = 1;
    public Action<float> move;

    bool pointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    void Update()
    {
        if (pointerDown)
        {
            move(dir);
        }
    }
}