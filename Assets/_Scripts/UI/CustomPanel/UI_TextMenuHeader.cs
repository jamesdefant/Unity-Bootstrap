using TMPro;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_TextMenuHeader : UI_Text
    {
        //Image _textBackground;
        //TextMeshProUGUI _text;


        //protected override void CacheReferences()
        //{
        //    //_textBackground = GetComponent<Image>();
        //    //_text = GetComponentInChildren<TextMeshProUGUI>();
        //}

        protected override void SetValues()
        {
            //_textBackground.color = UI_Styles.Instance.TextBGColor;

            //_text.color = UI_Styles.Instance.TextColor;
            _text.fontSize = UI_Styles.Instance.TextMenuHeaderFontSize;

            _verticalLayoutGroup.padding = UI_Styles.GetPadding(UI_Styles.Instance.TextMenuHeaderPadding);
        }
    }
}