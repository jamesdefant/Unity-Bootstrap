using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace Com.SoulSki.UI
{
    public enum ButtonState
    {
        NORMAL,
        HIGHLIGHTED,
        PRESSED,
        SELECTED,
        DISABLED
    }

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

        ButtonState _buttonState = ButtonState.NORMAL;

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
                if (value == false)
                {
                    _buttonState = ButtonState.DISABLED;
                }
                _image.color = GetColorFromState();
                _interactable = value;
            }
        }
        public Color NormalColor
        {
            get => _normalColor;
            set
            {
                _normalColor = value;
                _image.color = _normalColor;
            }
        }
        public Color HighlightedColor
        {
            get => _highlightedColor;
            set
            {
                _highlightedColor = value;
                _image.color = _highlightedColor;
            }
        }
        public Color PressedColor
        {
            get => _pressedColor;
            set
            {
                _pressedColor = value;
                _image.color = _pressedColor;
            }
        }
        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                _image.color = _selectedColor;
            }
        }
        public Color DisabledColor
        {
            get => _disabledColor;
            set
            {
                _disabledColor = value;
                _image.color = _disabledColor;
            }
        }

        public Color NormalTextColor
        {
            get => _normalTextColor;
            set
            {
                _normalTextColor = value;
                _text.color = _normalTextColor;
            }
        }
        public Color SelectedTextColor
        {
            get => _selectedTextColor;
            set
            {
                _selectedTextColor = value;
                //_text.color = _selectedTextColor;
            }
        }
        public float FadeDuration
        {
            get => _fadeDuration;
            set => _fadeDuration = value;
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
            _image.color = GetColorFromState();

            //if (!_interactable)
            //{
            //    _image.color = _disabledColor;
            //}
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
            if (_interactable)
            {
                _buttonState = ButtonState.HIGHLIGHTED;

                StartCoroutine(ChangeToColor(_highlightedColor));

                // Callback
                _onMouseEnter.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_interactable)
            {
                _buttonState = ButtonState.NORMAL;

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
                //_buttonState = ButtonState.SELECTED;

                StartCoroutine(ChangeToColor(_selectedColor));
                if(_isTextColorUnique)
                    StartCoroutine(ChangeTextColor(_selectedTextColor));

                _isSelected = true;
            }
        }
        public void Deselect()
        {
            if (_interactable)
            {
                _buttonState = ButtonState.NORMAL;

                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(ChangeToColor(_normalColor));
                    if (_isTextColorUnique)
                        StartCoroutine(ChangeTextColor(_normalTextColor));
                }
                else
                {
                    Awake();
                    _image.color = _normalColor;
                    _text.color = _normalTextColor;
                }
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

        Color GetColorFromState()
        {
            switch (_buttonState)
            {
                default:
                case ButtonState.NORMAL:
                    return _normalColor;
                case ButtonState.HIGHLIGHTED:
                    return _highlightedColor;
                case ButtonState.PRESSED:
                    return _pressedColor;
                case ButtonState.SELECTED:
                    return _selectedColor;
                case ButtonState.DISABLED:
                    return _disabledColor;
            }
        }
        #endregion
    }
}