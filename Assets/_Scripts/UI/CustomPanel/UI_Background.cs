using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_Background : UI_Component
    {
        Image _image;

        protected override void CacheReferences()
        {
            _image = GetComponent<Image>();
        }

        protected override void SetValues()
        {
            _image.color = UI_Styles.Instance.PanelBGColor;
        }
    }
}