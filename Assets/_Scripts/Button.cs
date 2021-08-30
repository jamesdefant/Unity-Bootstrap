using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Com.SoulSki.UI
{
    [ExecuteInEditMode]
    public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {

        #region Fields
        //-----------------------------------------------
        [Header("Button State Colors")]
        [SerializeField] Color _normalColor = Color.white;
        [SerializeField] Color _highlightedColor = Color.white;
        [SerializeField] Color _pressedColor = Color.grey;
        [SerializeField] Color _selectedColor = Color.white;
        [SerializeField] Color _disabledColor = Color.grey;

        [Space()]
        [SerializeField] UnityEvent _onClick;
        [SerializeField] UnityEvent _onMouseEnter;


        Image _image;

        #endregion

        void Awake()
        {
            _image = GetComponent<Image>();
            _image.color = _normalColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // Callback
            _onClick.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _image.color = _pressedColor;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            _image.color = _normalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Callback
            _onMouseEnter.Invoke();

            _image.color = _highlightedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = _normalColor;
        }
    }
}