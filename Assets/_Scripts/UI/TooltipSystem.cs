using UnityEngine;

namespace Com.SoulSki.UI
{
    public class TooltipSystem : MonoBehaviour
    {
        [SerializeField] float _delayTime = 1f;
        [SerializeField] float _fadeInTime = 0.2f;
        [SerializeField] float _fadeOutTime = 0.1f;
        [SerializeField] CanvasGroup _canvasGroup;

        private static TooltipSystem _current;
        private static LTDescr _delay;

        ITooltip _tooltip;


        private void Awake()
        {
            _current = this;
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
            _delay = LeanTween.delayedCall(_current._delayTime, () =>
            {
                _current._tooltip.SetText(content, header);
                LeanTween.alphaCanvas(_current._canvasGroup, 1, _current._fadeInTime);
            });
        }

        /// <summary>
        /// Fade tooltip out
        /// </summary>
        public static void Hide()
        {
            if(_delay != null)
                LeanTween.cancel(_delay.uniqueId);
            LeanTween.alphaCanvas(_current._canvasGroup, 0, _current._fadeOutTime);
        }

        /// <summary>
        /// Hide the tooltip immediately
        /// </summary>
        public static void HideImmediate()
        {
            if (_delay != null)
                LeanTween.cancel(_delay.uniqueId);
            _current._canvasGroup.alpha = 0;
        }
    }
}