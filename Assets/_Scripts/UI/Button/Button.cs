using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace Com.SoulSki.UI
{
    [ExecuteInEditMode]
    [AddComponentMenu("SoulSki_UI/Button")]
    public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, 
                          IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {

        #region Fields
        //-----------------------------------------------
        [SerializeField] bool _interactable = true;

        [Header("Button State Colors")]
        [SerializeField] Color _normalColor = Color.white;
        [SerializeField] Color _highlightedColor = Color.white;
        [SerializeField] Color _pressedColor = Color.grey;
        [SerializeField] Color _selectedColor = Color.black;
        [SerializeField] Color _disabledColor = Color.grey;
        [Space()]
        [SerializeField] Color _normalTextColor = Color.white;
        [SerializeField] Color _selectedTextColor = Color.black;

        [Space()]
        [SerializeField] float _fadeDuration = 0.2f;

        [Space()]
        [SerializeField] UnityEvent _onClick;
        [SerializeField] UnityEvent _onMouseEnter;

        bool _isSelected;
        Image _image;
        TextMeshProUGUI _text;
        bool _isTextColorUnique;


        #endregion

        #region Properties
        //-----------------------------------------------

        public bool Interactable
        {
            get => _interactable;
            set 
            {
                _image.color = (value == false) ? _disabledColor : _normalColor;
                _interactable = value;
            }
        }
        public Color NormalColor
        {
            get => _normalColor;
            set => _normalColor = value;
        }
        public Color HighlightedColor
        {
            get => _highlightedColor;
            set => _highlightedColor = value;
        }
        public Color PressedColor
        {
            get => _pressedColor;
            set => _pressedColor = value;
        }
        public Color SelectedColor
        {
            get => _selectedColor;
            set => _selectedColor = value;
        }
        public Color DisabledColor
        {
            get => _disabledColor;
            set => _disabledColor = value;
        }

        public Color NormalTextColor
        {
            get => _normalTextColor;
            set => _normalTextColor = value;
        }
        public Color SelectedTextColor
        {
            get => _selectedTextColor;
            set => _selectedTextColor = value;
        }
        #endregion

        #region Monobehaviour Callbacks
        //-----------------------------------------------

        void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _image = GetComponent<Image>();
            _image.color = _normalColor;

            _isTextColorUnique = _normalTextColor != _selectedTextColor;
            
        }

#if UNITY_EDITOR

        void LateUpdate()
        {
            if (!_interactable)
            {
                _image.color = _disabledColor;
            }
/*
            else
            {
                _image.color = _normalColor;
            }
*/
        }

#endif
#endregion

        #region Event Handlers
        //-----------------------------------------------

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_interactable)
            {
                Select();
                _onClick.Invoke();
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_interactable)
            {
                StartCoroutine(ChangeToColor(_pressedColor));
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_interactable)
            {
                StartCoroutine(ChangeToColor(_normalColor));
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_interactable && !_isSelected)
            {
                StartCoroutine(ChangeToColor(_highlightedColor));

                // Callback
                _onMouseEnter.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_interactable && !_isSelected)
            {
                StartCoroutine(ChangeToColor(_normalColor));
            }
        }

        #endregion

        #region Public Methods
        //-----------------------------------------------

        public void Select()
        {
            if (_interactable)
            {
                StartCoroutine(ChangeToColor(_selectedColor));
                if(_isTextColorUnique)
                    StartCoroutine(ChangeTextColor(_selectedTextColor));

                _isSelected = true;
            }
        }
        public void DeSelect()
        {
            if (_interactable)
            {
                StartCoroutine(ChangeToColor(_normalColor));
                if (_isTextColorUnique)
                    StartCoroutine(ChangeTextColor(_normalTextColor));

                _isSelected = false;
            }
        }

        #endregion

        #region Private Methods
        //-----------------------------------------------
/*
        IEnumerator ChangeToColor(Color newColor, Color newTextColor, bool changeText)
        {
            Color oldColor = _image.color;
            Color oldTextColor = _text.color;
            float elapsedTime = 0f;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
             
                _image.color = Color.Lerp(oldColor, newColor, elapsedTime / _fadeDuration);

                if(changeText)
                    _text.color = Color.Lerp(oldTextColor, newTextColor, elapsedTime / _fadeDuration);

                yield return null;
            }
        }
*/
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

        IEnumerator ChangeTextColor(Color newColor)
        {
            Color oldColor = _text.color;
            float elapsedTime = 0f;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                _text.color = Color.Lerp(oldColor, newColor, elapsedTime / _fadeDuration);
                yield return null;
            }
        }

        #endregion
    }
}