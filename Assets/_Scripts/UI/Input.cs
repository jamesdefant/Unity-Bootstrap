using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace Com.SoulSki.Common
{
    public class Input : MonoBehaviour
    {
        public static Input instance;
        InputSystemUIInputModule _inputModule;


        private void Awake()
        {
            instance = this;
            _inputModule = GetComponent<InputSystemUIInputModule>();
        }
        public static Vector2 MousePosition
        {
            get
            {
                if (instance == null)
                {
                    return new Vector2();
                }
                else
                {
                    return instance._inputModule.point.action.ReadValue<Vector2>();
                }
            }
        }
    }
}