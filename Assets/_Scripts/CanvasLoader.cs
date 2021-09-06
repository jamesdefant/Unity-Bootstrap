using Com.SoulSki.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.SoulSki.UI
{
    public class CanvasLoader : MonoBehaviour
    {
        [SerializeField] GameObject _launcherGO;
        [SerializeField] GameObject _tooltipGO;
         

        private void Awake()
        {
            Instantiate(_launcherGO);
            Instantiate(_tooltipGO);
        }
    }
}