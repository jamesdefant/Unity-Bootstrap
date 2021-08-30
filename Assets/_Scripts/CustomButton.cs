using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : Button, IPointerEnterHandler
{
    [SerializeField] UnityEvent _onMouseEnter;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        _onMouseEnter.Invoke();
    }
}
