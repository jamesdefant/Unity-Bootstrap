using UnityEngine;

namespace Com.SoulSki.UI
{
    public class TooltipSystem : MonoBehaviour
    {
        const float FADE_IN_TIME = 0.2f;
        const float FADE_OUT_TIME = 0.1f;

        private static TooltipSystem _current;

        Tooltip _tooltip;
        CanvasGroup _canvasGroup;

        private void Awake()
        {
            _current = this;
            _canvasGroup = GetComponent<CanvasGroup>();
            _tooltip = GetComponentInChildren<Tooltip>();
        }

        public static void Show(string content, string header = "")
        {
            _current._tooltip.SetText(content, header);

            LeanTween.alphaCanvas(_current._canvasGroup, 1, FADE_IN_TIME);
        }
        public static void Hide()
        {
            LeanTween.alphaCanvas(_current._canvasGroup, 0, FADE_OUT_TIME);
        }
    }
}