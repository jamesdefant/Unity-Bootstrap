using System.Collections;
using System.Collections.Generic;
using Com.SoulSki.Common;
using UnityEngine;

namespace Com.SoulSki.UI
{
    public class UI_Styles : SingletonScriptableObject<UI_Styles>
    {
        [Header("Panel")]
        [SerializeField] float _panelBorderWidth = 5f;
        [SerializeField] Color _panelBorderColor = Color.white;
        //[SerializeField] float _panelBorderMargin;

        [SerializeField] Color _panelBGColor = Color.blue;

        [Header("Text")]
        [SerializeField] Color _panelTextColor = Color.black;
        [SerializeField] Color _panelTextBGColor = Color.white;
        [SerializeField] int _h1 = 40;
        [SerializeField] int _h2 = 33;
        [SerializeField] int _h3 = 28;
        [SerializeField] int _h4 = 24;
        [SerializeField] int _h5 = 20;
        [SerializeField] int _h6 = 16;
        //[SerializeField] int _p = 16;



    }
}