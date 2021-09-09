using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    /// <summary>
    /// Initializes main UI elements with a common color scheme
    /// </summary>
    public class UI_Appearance : MonoBehaviour
    {

        [SerializeField] Color _backgroundColor;

        public static UI_Appearance Instance;

        List<Image> _backgroundElements = new List<Image>();
        List<Button> _buttonElements = new List<Button>();
        List<TextMeshProUGUI> _textElements = new List<TextMeshProUGUI>();

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;

        }

        public static void RegisterBackground(Image image)
        {
            Instance._backgroundElements.Add(image);
        }
        public static void RegisterButton(Button button)
        {
            Instance._buttonElements.Add(button);
        }
        public static void RegisterText(Image image)
        {
            Instance._backgroundElements.Add(image);
        }
    }
}