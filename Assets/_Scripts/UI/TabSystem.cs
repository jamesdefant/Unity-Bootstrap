using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class TabSystem : MonoBehaviour
    {

        [SerializeField] CustomButton[] _tabs;
        [SerializeField] GameObject[] _windows;


        public void Show(int index)
        {
            if(index < 0 || index > _windows.Length - 1)
            {
                Debug.LogErrorFormat("Index ({0}) does not exist in the _windows array.");
                return;
            }

            HideAll();
            _windows[index].gameObject.SetActive(true);
        }

        void HideAll()
        {
            foreach(GameObject go in _windows)
            {
                go.SetActive(false);
            }
        }
    }
}