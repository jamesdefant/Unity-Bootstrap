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
        public bool UpdateLive => _updateLive;

        [Header("Blocker")]
        [SerializeField] Color _blockerColor;
        public Color BlockerColor => _blockerColor;


        [Header("Panel")]
        [Range(0f, 50f)]
        [SerializeField] int _panelBorderWidth = 5;
        public int PanelBorderWidth => _panelBorderWidth;

        [SerializeField] Color _panelBorderColor = Color.white;
        public Color PanelBorderColor => _panelBorderColor;
        //[SerializeField] float _panelBorderMargin;

        [SerializeField] Color _panelBGColor = Color.blue;
        public Color PanelBGColor => _panelBGColor;

        //[Header("Text")]
        //[SerializeField] Color _panelTextColor = Color.black;
        //[SerializeField] Color _panelTextBGColor = Color.white;
        //[SerializeField] int _h1 = 40;
        //[SerializeField] int _h2 = 33;
        //[SerializeField] int _h3 = 28;
        //[SerializeField] int _h4 = 24;
        //[SerializeField] int _h5 = 20;
        //[SerializeField] int _h6 = 16;


        [Header("Buttons")]
        [Range(10f, 60f)]
        [SerializeField] float _buttonFontSize;
        public float ButtonFontSize => _buttonFontSize;
        [SerializeField] Color _buttonTextColor;
        public Color ButtonTextColor => _buttonTextColor;
        [SerializeField] Color _buttonSelectedTextColor;
        public Color ButtonSelectedTextColor => _buttonSelectedTextColor;
        [SerializeField] Vector3Int _buttonPadding;
        public Vector3Int ButtonPadding => _buttonPadding;
        [Space()]
        [SerializeField] ColorBlock _buttonColorBlock;
        public ColorBlock ButtonColorBlock => _buttonColorBlock;


        //[SerializeField] int _p = 16;


        public static RectOffset GetPadding(int value)
        {
            return new RectOffset(value, value, value, value);
        }
        public static (RectOffset padding, int spacing) GetPadding(Vector3Int value)
        {
            //RectOffset padding = new RectOffset(value.x, value.x, value.y, value.y);
            //int spacing = value.z;

            return (new RectOffset(value.x, value.x, value.y, value.y), value.z);
            //return (padding, spacing);
        }
    }
}