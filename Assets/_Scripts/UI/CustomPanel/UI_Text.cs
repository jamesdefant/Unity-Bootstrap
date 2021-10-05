using TMPro;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_Text : UI_Component
    {
        protected Image _textBackground;
        protected TextMeshProUGUI _text;
        protected VerticalLayoutGroup _verticalLayoutGroup;


        protected override void CacheReferences()
        {
            _textBackground = GetComponent<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        }

        protected override void SetValues()
        {
            _textBackground.color = UI_Styles.Instance.TextBGColor;

            _text.color = UI_Styles.Instance.TextColor;
            _text.fontSize = UI_Styles.Instance.TextFontSize;

            _verticalLayoutGroup.padding = UI_Styles.GetPadding(UI_Styles.Instance.TextPadding);
            
        }
    }
}