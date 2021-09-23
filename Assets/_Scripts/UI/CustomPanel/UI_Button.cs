using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_Button : UI_Component
    {
        Button _button;
        TextMeshProUGUI _text;
        VerticalLayoutGroup _vertLayoutGroup, _parentVertLayoutGroup;

        protected override void CacheReferences()
        {
            _button = GetComponent<Button>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _vertLayoutGroup = GetComponent<VerticalLayoutGroup>();
            _parentVertLayoutGroup = transform.parent.GetComponent<VerticalLayoutGroup>();
        }

        protected override void SetValues()
        {
            _text.fontSize = UI_Styles.Instance.ButtonFontSize;
            _button.NormalTextColor = UI_Styles.Instance.ButtonTextColor;
            _button.SelectedTextColor = UI_Styles.Instance.ButtonSelectedTextColor;

            (RectOffset padding, int spacing) = UI_Styles.GetPadding(UI_Styles.Instance.ButtonPadding);
            _vertLayoutGroup.padding = padding;
            _parentVertLayoutGroup.spacing = spacing;


            ColorBlock colorBlock = UI_Styles.Instance.ButtonColorBlock;

            _button.NormalColor = colorBlock.normalColor;
            _button.HighlightedColor = colorBlock.highlightedColor;
            _button.PressedColor = colorBlock.pressedColor;
            _button.SelectedColor = colorBlock.selectedColor;
            _button.DisabledColor = colorBlock.disabledColor;
            _button.FadeDuration = colorBlock.fadeDuration;


            //_text.color = UI_Styles.Instance.ButtonTextColor;
        }
    }
}