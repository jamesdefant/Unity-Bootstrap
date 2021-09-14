using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Com.SoulSki.UI
{
    public interface ITooltip
    {
        void Initialize();
        void SetText(string content, string header = "");
    }

    //[ExecuteInEditMode()]
    public class Tooltip : MonoBehaviour, ITooltip
    {
        #region Fields
        //-----------------------------------------------

        [SerializeField] TextMeshProUGUI _headerField;
        [SerializeField] TextMeshProUGUI _contentField;
        [SerializeField] LayoutElement _layoutElement;
        [SerializeField] int _characterWrapLimit;

        RectTransform _rectTransform;

        #endregion

        #region Public Methods
        //-----------------------------------------------

        public void Initialize()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        public void Initialize(TooltipAppearance appearance)
        {
            _rectTransform = GetComponent<RectTransform>();

        }


        public void SetText(string content, string header = "")
        {           
            if (string.IsNullOrEmpty(header))
            {
                _headerField.gameObject.SetActive(false);
            }
            else
            {
                _headerField.gameObject.SetActive(true);
                _headerField.text = header;
            }

            _contentField.text = content;

            // Size the tooltip
            int headerLength = _headerField.text.Length;
            int contentLength = _contentField.text.Length;

            _layoutElement.enabled =
                (headerLength > _characterWrapLimit || contentLength > _characterWrapLimit)
                ? true : false;
        }

        #endregion

        #region Monobehaviour Callbacks
        //-----------------------------------------------

        //private void Awake()
        //{
        //    _rectTransform = GetComponent<RectTransform>();
        //}
        private void Update()
        {
            if (Application.isEditor)
            {
                int headerLength = _headerField.text.Length;
                int contentLength = _contentField.text.Length;

                _layoutElement.enabled =
                    (headerLength > _characterWrapLimit || contentLength > _characterWrapLimit)
                    ? true : false;
            }

            Vector2 position = Common.Input.MousePosition;

            SetPivot(position);

            transform.position = position;
        }
        /*
                // Smooth
                void SetPivot(Vector2 position)
                {
                    float pivotX = position.x / Screen.width;
                    float pivotY = position.y / Screen.height;

                    _rectTransform.pivot = new Vector2(pivotX, pivotY);
                }
        */

        #endregion

        #region Private Methods
        //-----------------------------------------------

        void SetPivot(Vector2 position)
        {
            int pivotX = 0, pivotY = 1;

            // Check if the tooltip is off the right of the screen
            if (_rectTransform.rect.width > Screen.width - position.x)
                pivotX = 1;

            if (_rectTransform.rect.height > Screen.height - position.y)
                pivotY = 0;

            _rectTransform.pivot = new Vector2(pivotX, pivotY);
        }

        #endregion
    }

    public class TooltipAppearance
    {
        public Font Font { get; private set; }
        public int HeaderFontSize { get; private set; }
        public int ContentFontSize { get; private set; }
        public Color BackgroundColor { get; private set; }
        public Color TextColor { get; private set; }

        public TooltipAppearance(
            Font font
            , int headerFontSize
            , int contentFontSize
            , Color backgroundColor
            , Color textColor)
        {
            Font = font;
            HeaderFontSize = headerFontSize;
            ContentFontSize = contentFontSize;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
    }
}