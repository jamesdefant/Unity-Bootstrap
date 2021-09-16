using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.SoulSki.UI
{
    [CreateAssetMenu(menuName = "SoulSki/UI/TooltipAppearance")]
    public class TooltipAppearance : ScriptableObject
    {
        [SerializeField] int _borderSize = 4;
        [SerializeField] TMPro.TMP_FontAsset _font;
        [SerializeField] int _headerFontSize = 20;
        [SerializeField] int _contentFontSize = 16;
        [SerializeField] Color _backgroundColor = Color.black;
        [SerializeField] Color _textColor = Color.white;
        [SerializeField] Color _borderColor = Color.white;

        public int BorderSize => _borderSize;
        public TMPro.TMP_FontAsset Font => _font;
        public int HeaderFontSize => _headerFontSize;
        public int ContentFontSize => _contentFontSize;
        public Color BackgroundColor => _backgroundColor;
        public Color TextColor => _textColor;
        public Color BorderColor => _borderColor;

        //public TooltipAppearance(
        //    int borderSize
        //    , Font font
        //    , int headerFontSize
        //    , int contentFontSize
        //    , Color backgroundColor
        //    , Color textColor
        //    , Color borderColor)
        //{
        //    _borderSize = borderSize;
        //    _font = font;
        //    _headerFontSize = headerFontSize;
        //    _contentFontSize = contentFontSize;
        //    _backgroundColor = backgroundColor;
        //    _textColor = textColor;
        //    _borderColor = borderColor;
        //}
    }
}