using System.Collections;
using System.Collections.Generic;
using Com.SoulSki.Common;
using UnityEngine;
using UnityEngine.UI;
using Vector2Int = UnityEngine.Vector2Int;

namespace Com.SoulSki.UI
{
    [CreateAssetMenu(menuName = "SoulSki/UI/Styles")]
    public class UI_Styles : SingletonScriptableObject<UI_Styles>
    {
        [SerializeField] bool _updateLive = true;

        [Header("Blocker")]
        [SerializeField] Color _blockerColor;

        [Header("Panel")]
        [Range(0f, 50f)]
        [SerializeField] int _panelBorderWidth = 5;
        [SerializeField] Color _panelBorderColor = Color.white;
        [SerializeField] Color _panelBGColor = Color.blue;
        [Space()]
        [SerializeField] Vector2Int _panelPadding;
        [SerializeField] int _panelSpacingVertical = 20;
        [SerializeField] int _panelSpacingHorizontal = 20;

        [Header("Text")]
        [SerializeField] Color _textColor = Color.black;
        [SerializeField] Color _textBGColor = Color.white;
        [SerializeField] float _textFontSize = 18f;
        [SerializeField] Vector2Int _textPadding;
        [Header("TextHeader")]
        [SerializeField] float _textHeaderFontSize = 26f;
        [SerializeField] Vector2Int _textHeaderPadding;
        [SerializeField] float _textMenuHeaderFontSize = 26f;
        [SerializeField] Vector2Int _textMenuHeaderPadding;
        //[Header("Text Header")]

        //[SerializeField] int _h1 = 40;
        //[SerializeField] int _h2 = 33;
        //[SerializeField] int _h3 = 28;
        //[SerializeField] int _h4 = 24;
        //[SerializeField] int _h5 = 20;
        //[SerializeField] int _h6 = 16;


        [Header("Buttons")]
        [Range(10f, 60f)]
        [SerializeField] float _buttonFontSize = 23.7f;
        [SerializeField] Color _buttonTextColor = Color.black;
        [SerializeField] Color _buttonSelectedTextColor;
        [Space()]
        [SerializeField] Vector2Int _buttonPadding;
        [SerializeField] int _buttonSpacingVertical = 20;
        [SerializeField] int _buttonSpacingHorizontal = 20;
        [Space()]
        [SerializeField] ColorBlock _buttonColorBlock;



        //[SerializeField] int _p = 16;


        #region Properties
        //-----------------------------------------------

        public bool UpdateLive => _updateLive;

        public Color BlockerColor => _blockerColor;

        public int PanelBorderWidth => _panelBorderWidth;
        public Color PanelBorderColor => _panelBorderColor;
        public Color PanelBGColor => _panelBGColor;
        public Vector2Int PanelPadding => _panelPadding;
        public int PanelSpacingVertical => _panelSpacingVertical;
        public int PanelSpacingHorizontal => _panelSpacingHorizontal;

        public Color TextColor => _textColor;
        public Color TextBGColor => _textBGColor;
        public float TextFontSize => _textFontSize;
        public Vector2Int TextPadding => _textPadding;

        public float TextHeaderFontSize => _textHeaderFontSize;
        public Vector2Int TextHeaderPadding => _textHeaderPadding;

        public float TextMenuHeaderFontSize => _textMenuHeaderFontSize;
        public Vector2Int TextMenuHeaderPadding => _textMenuHeaderPadding;

        public float ButtonFontSize => _buttonFontSize;
        public Color ButtonTextColor => _buttonTextColor;
        public Color ButtonSelectedTextColor => _buttonSelectedTextColor;
        public Vector2Int ButtonPadding => _buttonPadding;
        public int ButtonSpacingVertical => _buttonSpacingVertical;
        public int ButtonSpacingHorizontal => _buttonSpacingHorizontal;
        public ColorBlock ButtonColorBlock => _buttonColorBlock;

        #endregion


        public static RectOffset GetPadding(int value)
        {
            return new RectOffset(value, value, value, value);
        }
        public static RectOffset GetPadding(Vector2Int value)
        {
            //RectOffset padding = new RectOffset(value.x, value.x, value.y, value.y);
            //int spacing = value.z;

            return new RectOffset(value.x, value.x, value.y, value.y);
            //return (padding, spacing);
        }
    }
}