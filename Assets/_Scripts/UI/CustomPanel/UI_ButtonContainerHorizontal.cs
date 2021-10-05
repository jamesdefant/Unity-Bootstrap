using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_ButtonContainerHorizontal : UI_Component
    {
        Image _image;
        HorizontalLayoutGroup _horizontalLayoutGroup;

        protected override void CacheReferences()
        {
            _image = GetComponent<Image>();
            _horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        }

        protected override void SetValues()
        {
            _image.color = UI_Styles.Instance.PanelBGColor;
            _horizontalLayoutGroup.spacing = UI_Styles.Instance.ButtonSpacingHorizontal;
        }
    }
}