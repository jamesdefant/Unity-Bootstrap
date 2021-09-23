using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class UI_Blocker : UI_Component
    {
        Image _image;

        protected override void CacheReferences()
        {
            _image = GetComponent<Image>();
        }

        protected override void SetValues()
        {
            _image.color = UI_Styles.Instance.BlockerColor;
        }
    }
}