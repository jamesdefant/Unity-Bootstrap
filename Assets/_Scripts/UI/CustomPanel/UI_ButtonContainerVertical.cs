using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_ButtonContainerVertical : UI_Component
    {
        Image _image;
        VerticalLayoutGroup _verticalLayoutGroup;

        protected override void CacheReferences()
        {
            _image = GetComponent<Image>();
            _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        }

        protected override void SetValues()
        {
            _image.color = UI_Styles.Instance.PanelBGColor;
            _verticalLayoutGroup.spacing = UI_Styles.Instance.ButtonSpacingVertical;
        }
    }
}