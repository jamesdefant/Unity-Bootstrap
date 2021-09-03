using UnityEngine;

namespace Com.SoulSki.UI
{
    public class TooltipSystem : MonoBehaviour
    {
        [SerializeField] float _fadeInTime = 0.2f;
        [SerializeField] float _fadeOutTime = 0.1f;

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

            LeanTween.alphaCanvas(_current._canvasGroup, 1, _current._fadeInTime);


        }
        public static void Hide()
        {
            LeanTween.alphaCanvas(_current._canvasGroup, 0, _current._fadeOutTime);
        }
    }
}