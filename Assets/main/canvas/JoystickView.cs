using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum JoyStickDirection { Horizontal, Vertical, Both}

public class JoystickView : MonoBehaviour , IDragHandler , IPointerDownHandler , IPointerUpHandler
{

    public JoyStickDirection JoystickDirection = JoyStickDirection.Both;
    public RectTransform background;
    public RectTransform Handle;
    [Range(0, 2f)] public float HandleLimit = 1f;
    private Vector2 input = Vector2.zero;

    public float Vertical { get { return input.y; } }

    public float Horizontal { get { return input.x; } }

    public Vector2 JoyPosition = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        background.gameObject.SetActive(true);
        input = Vector2.zero;
        JoyPosition = eventData.position;
        background.position = eventData.position;
        Handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 JoyDirection = eventData.position - JoyPosition;
        input = (JoyDirection.magnitude > background.sizeDelta.x / 2f) ? JoyDirection.normalized :
            JoyDirection / (background.sizeDelta.x / 2f);
        if (JoystickDirection == JoyStickDirection.Horizontal)
        {
            input = new Vector2(input.x, 0f);
        }
        if (JoystickDirection == JoyStickDirection.Vertical)
        {
            input = new Vector2(0f , input.y);
        }
        Handle.anchoredPosition = (input * background.sizeDelta.x / 2f) * HandleLimit;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}
