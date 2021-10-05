using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_BackgroundHorizontal : UI_Component
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

            _horizontalLayoutGroup.spacing = UI_Styles.Instance.PanelSpacingHorizontal;
            _horizontalLayoutGroup.padding = UI_Styles.GetPadding(UI_Styles.Instance.PanelPadding);
        }
    }
}