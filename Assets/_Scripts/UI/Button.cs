using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Com.SoulSki.UI
{
    [ExecuteInEditMode]
    public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, 
                          IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {

        #region Fields
        //-----------------------------------------------
        [Header("Button State Colors")]
        [SerializeField] Color _normalColor = Color.white;
        [SerializeField] Color _highlightedColor = Color.white;
        [SerializeField] Color _pressedColor = Color.grey;
        [SerializeField] Color _selectedColor = Color.black;
        [SerializeField] Color _disabledColor = Color.grey;

        [Space()]
        [SerializeField] float _fadeDuration = 0.2f;

        [Space()]
        [SerializeField] UnityEvent _onClick;
        [SerializeField] UnityEvent _onMouseEnter;

        bool _isSelected;


        Image _image;

        #endregion

        void Awake()
        {
            _image = GetComponent<Image>();
            _image.color = _normalColor;
        }

        public void Select()
        {
            StartCoroutine(ChangeToColor(_selectedColor));
            //_image.color = _selectedColor;
            _isSelected = true;
        }
        public void DeSelect()
        {
            _image.color = _normalColor;
            _isSelected = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Select();
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
            if (!_isSelected)
            {
                _image.color = _highlightedColor;

                // Callback
                _onMouseEnter.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(!_isSelected)
                _image.color = _normalColor;
        }



        IEnumerator ChangeToColor(Color newColor)
        {
            Color oldColor = _image.color;
            float elapsedTime = 0f;

            while(elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                _image.color = Color.Lerp(oldColor, newColor, elapsedTime / _fadeDuration);
                yield return null;
            }
        }
    }
}