using UnityEngine;

namespace Com.SoulSki.UI
{
    public class TooltipSystem : MonoBehaviour
    {
        [SerializeField] float _fadeInTime = 0.2f;
        [SerializeField] float _fadeOutTime = 0.1f;
        //[SerializeField] Tooltip _tooltipReference;
        [SerializeField] CanvasGroup _canvasGroup;

        private static TooltipSystem _current;

        ITooltip _tooltip;


        private void Awake()
        {
            _current = this;
            //_canvasGroup = GetComponent<CanvasGroup>();
            _tooltip = _canvasGroup.GetComponentInChildren<Tooltip>();
            _tooltip.Initialize();
        }

        /// <summary>
        /// Set the tooltip text and fade in
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="header">Header.</param>
        public static void Show(string content, string header = "")
        {
            _current._tooltip.SetText(content, header);

            LeanTween.alphaCanvas(_current._canvasGroup, 1, _current._fadeInTime);
        }

        /// <summary>
        /// Fade tooltip out
        /// </summary>
        public static void Hide()
        {
            LeanTween.alphaCanvas(_current._canvasGroup, 0, _current._fadeOutTime);
        }

        /// <summary>
        /// Hide the tooltip immediately
        /// </summary>
        public static void HideImmediate()
        {
            _current._canvasGroup.alpha = 0;
        }
    }
}